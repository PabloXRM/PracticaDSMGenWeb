// ReseñaController.cs
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
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DSM.Controllers
{
    public class ReseñaController : BasicController
    {
        // GET: ReseñaController
        public ActionResult Index()
        {
            SessionInitialize();
            ReseñaRepository resRepository = new ReseñaRepository(session);
            ReseñaCEN resCEN = new ReseñaCEN(resRepository);

            IList<ReseñaEN> listEN = resCEN.ReadAll(0, -1);

            IEnumerable<ReseñaViewModel> listRes =
                new ReseñaAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listRes);
        }

        // GET: ReseñaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ReseñaRepository resRepository = new ReseñaRepository(session);
            ReseñaCEN resCEN = new ReseñaCEN(resRepository);

            ReseñaEN resEN = resCEN.ReadOID(id);
            ReseñaViewModel resView = new ReseñaAssembler().ConvertENToModelUI(resEN);

            SessionClose();

            return View(resView);
        }

        // GET: ReseñaController/Create
        public ActionResult Create()
        {
            SessionInitialize();
            ProductoRepository pRepo = new ProductoRepository(session);
            ProductoCEN pCEN = new ProductoCEN(pRepo);
            var productos = pCEN.ReadAll(0, -1);

            ViewBag.Productos = new SelectList(productos, "Id", "Descripcion");
            SessionClose();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReseñaViewModel res)
        {
            if (!ModelState.IsValid)
            {
                SessionInitialize();
                ProductoRepository pRepo = new ProductoRepository(session);
                ProductoCEN pCEN = new ProductoCEN(pRepo);
                var productos = pCEN.ReadAll(0, -1);
                ViewBag.Productos = new SelectList(productos, "Id", "Descripcion");
                SessionClose();

                return View(res);
            }

            try
            {
                ReseñaRepository resRepo = new ReseñaRepository();
                ReseñaCEN resCEN = new ReseñaCEN(resRepo);

                string emailUsuario = "cliente@demo.com";

                resCEN.New_(
                    emailUsuario,
                    res.IdProducto,     // ahora cogemos el valor del SELECT
                    res.Descripcion,
                    res.Nota,
                    res.Fecha
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(res);
            }
        }


        // GET: ReseñaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ReseñaRepository resRepo = new ReseñaRepository(session);
            ReseñaCEN resCEN = new ReseñaCEN(resRepo);

            ReseñaEN resEN = resCEN.ReadOID(id);
            ReseñaViewModel resView = new ReseñaAssembler().ConvertENToModelUI(resEN);

            SessionClose();
            return View(resView);
        }

        // POST: ReseñaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReseñaViewModel res)
        {
            if (!ModelState.IsValid)
            {
                return View(res);
            }

            try
            {
                ReseñaRepository resRepo = new ReseñaRepository();
                ReseñaCEN resCEN = new ReseñaCEN(resRepo);

                // Recuperamos la reseña actual de la BD
                ReseñaEN actual = resCEN.ReadOID(res.Id);

                if (actual == null)
                {
                    ModelState.AddModelError(string.Empty, "Reseña no encontrada.");
                    return View(res);
                }

                // Ajusta la firma de Modify a la que tengas realmente
                resCEN.Modify(
                    res.Id,
                    res.Descripcion,
                    res.Nota,
                    res.Fecha
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(res);
            }
        }

        // GET: ReseñaController/Delete/5
        public ActionResult Delete(int id)
        {
            ReseñaRepository resRepo = new ReseñaRepository();
            ReseñaCEN resCEN = new ReseñaCEN(resRepo);
            resCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: ReseñaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
