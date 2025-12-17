using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Controllers
{
    public class ResenaController : BasicController
    {
        private bool IsAdmin() => HttpContext.Session.GetString("IsAdmin") == "true";

        private UsuarioViewModel GetUser()
            => HttpContext.Session.Get<UsuarioViewModel>("usuario");

        // ============================
        // USER: reseñas de un producto
        // GET: /Resena/Producto?productoId=5
        // ============================
        public ActionResult Producto(int productoId)
        {
            // Redirigir a la vista de detalle del producto en la tienda,
            // donde se muestran las reseñas.
            return RedirectToAction("Producto", "Tienda", new { id = productoId });
        }

        // ============================
        // USER: mis reseñas
        // GET: /Resena/Mias
        // ============================
        public ActionResult Mias()
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");

            try
            {
                SessionInitialize();
                var repo = new ReseñaRepository(session);
                var cen = new ReseñaCEN(repo);

                var listEN = cen.ReadAll(0, -1);
                var listVM = new ResenaAssembler()
                    .ConvertListENToViewModel(listEN)
                    .Where(r => r.UsuarioEmail == u.email)
                    .OrderByDescending(r => r.Fecha)
                    .ToList();

                return View("Mias", listVM);
            }
            finally
            {
                try { SessionClose(); } catch { }
            }
        }

        // ============================
        // ADMIN: gestionar reseñas (listado global)
        // GET: /Resena/Index
        // ============================
        public ActionResult Index()
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (!IsAdmin()) return RedirectToAction("Index", "Home");

            try
            {
                SessionInitialize();
                var repo = new ReseñaRepository(session);
                var cen = new ReseñaCEN(repo);

                IList<ReseñaEN> listEN = cen.ReadAll(0, -1);
                var listVM = new ResenaAssembler().ConvertListENToViewModel(listEN).ToList();
                return View(listVM);
            }
            finally
            {
                try { SessionClose(); } catch { }
            }
        }

        // ============================
        // USER+ADMIN: details
        // admin: cualquiera
        // user: solo si es suya
        // ============================
        public ActionResult Details(int id)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");

            ResenaViewModel vm;

            try
            {
                SessionInitialize();
                var repo = new ReseñaRepository(session);
                var cen = new ReseñaCEN(repo);

                var en = cen.ReadOID(id);
                vm = new ResenaAssembler().ConvertENToModelUI(en);
            }
            finally
            {
                try { SessionClose(); } catch { }
            }

            if (vm == null) return RedirectToAction("Index", "Home");

            if (!IsAdmin() && vm.UsuarioEmail != u.email)
                return RedirectToAction("Index", "Home");

            return View(vm);
        }

        // ============================
        // USER: crear reseña (para un producto)
        // GET: /Resena/Create?productoId=5
        // ============================
        public ActionResult Create(int productoId)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (IsAdmin()) return RedirectToAction("Index", "Home"); // admin no reseña

            return View(new ResenaViewModel
            {
                ProductoId = productoId,
                UsuarioEmail = u.email,
                Fecha = DateTime.Today
            });
        }

        // POST: /Resena/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResenaViewModel model)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (IsAdmin()) return RedirectToAction("Index", "Home");

            // blindaje: el autor siempre es el usuario logueado
            model.UsuarioEmail = u.email;
            if (model.Fecha == default) model.Fecha = DateTime.Today;

            if (!ModelState.IsValid) return View(model);

            try
            {
                var repo = new ReseñaRepository();
                var cen = new ReseñaCEN(repo);

                cen.New_(model.UsuarioEmail, model.ProductoId, model.Descripcion, model.Nota, model.Fecha);

                // Vuelve al detalle del producto (Tienda/Producto/{id})
                return RedirectToAction("Producto", "Tienda", new { id = model.ProductoId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // ============================
        // ADMIN: borrar reseña desde el producto
        // POST: /Resena/DeleteFromProducto
        // ============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromProducto(int idResena, int productoId)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (!IsAdmin()) return RedirectToAction("Index", "Home");

            try
            {
                var repo = new ReseñaRepository();
                var cen = new ReseñaCEN(repo);
                cen.Destroy(idResena);
            }
            catch { }

            return RedirectToAction("Producto", "Tienda", new { id = productoId });
        }

        // ============================
        // ADMIN: editar (opcional)
        // ============================
        public ActionResult Edit(int id)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (!IsAdmin()) return RedirectToAction("Index", "Home");

            try
            {
                SessionInitialize();
                var repo = new ReseñaRepository(session);
                var cen = new ReseñaCEN(repo);
                var en = cen.ReadOID(id);
                var vm = new ResenaAssembler().ConvertENToModelUI(en);
                return View(vm);
            }
            finally
            {
                try { SessionClose(); } catch { }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResenaViewModel model)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (!IsAdmin()) return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid) return View(model);

            try
            {
                var repo = new ReseñaRepository();
                var cen = new ReseñaCEN(repo);
                cen.Modify(model.Id, model.Descripcion, model.Nota, model.Fecha);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // ============================
        // ADMIN: borrar resea (GET)
        // GET: /Resena/Delete/5
        // ============================
        public ActionResult Delete(int id)
        {
            var u = GetUser();
            if (u == null) return RedirectToAction("Login", "Usuario");
            if (!IsAdmin()) return RedirectToAction("Index", "Home");

            try
            {
                var repo = new ReseñaRepository();
                var cen = new ReseñaCEN(repo);
                cen.Destroy(id);
            }
            catch { }

            return RedirectToAction(nameof(Index));
        }
    }
}
