using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using DSM.Filters;

namespace DSM.Controllers
{
    public class EstanteriaController : BasicController
    {
        [AdminOnly]
        // GET: EstanteriaController
        public ActionResult Index()
        {
            SessionInitialize();
            EstanteriaRepository estRepository = new EstanteriaRepository(session);
            EstanteriaCEN estCEN = new EstanteriaCEN(estRepository);

            IList<EstanteriaEN> listEN = estCEN.ReadAll(0, -1);

            IEnumerable<EstanteriaViewModel> listArts =
                new EstanteriaAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listArts);
        }

        // GET: EstanteriaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            EstanteriaRepository estRepo = new EstanteriaRepository(session);
            EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);

            EstanteriaEN estEN = estCEN.ReadOID(id);
            EstanteriaViewModel estView = new EstanteriaAssembler().ConvertENToModelUI(estEN);

            SessionClose();
            return View(estView);
        }

        // GET: EstanteriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstanteriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstanteriaViewModel est)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            if (!ModelState.IsValid)
            {
                return View(est);
            }

            try
            {
                EstanteriaRepository estRepo = new EstanteriaRepository();
                EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);

                // Crear estantería asociada al usuario autenticado
                estCEN.New_(
                    u.email,  // Usuario desde sesión
                    null,     // Sin productos por defecto
                    est.Descripcion,
                    "0/10",   // Valoración por defecto
                    0,        // Visitas por defecto
                    true      // Visible por defecto
                );

                return RedirectToAction("EstanteriaVirtual", "Usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex.Message);
                return View(est);
            }
        }

        // GET: EstanteriaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            EstanteriaRepository estRepo = new EstanteriaRepository(session);
            EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);

            EstanteriaEN estEN = estCEN.ReadOID(id);
            EstanteriaViewModel estView = new EstanteriaAssembler().ConvertENToModelUI(estEN);

            SessionClose();
            return View(estView);
        }

        // POST: EstanteriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstanteriaViewModel est)
        {
            if (!ModelState.IsValid)
            {
                return View(est);
            }

            try
            {
                EstanteriaRepository estRepo = new EstanteriaRepository();
                EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);

                // Usamos los valores de la BD para los campos que no se editan en el formulario
                estCEN.Modify(
                    est.Id,
                    est.Descripcion,
                    est.Valoracion,
                    est.Visitas
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(est);
            }
        }

        // GET: EstanteriaController/Delete/5
        public ActionResult Delete(int id)
        {
            EstanteriaRepository estRepo = new EstanteriaRepository();
            EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);
            estCEN.Destroy(id);


            return RedirectToAction(nameof(Index));
        }

        // POST: EstanteriaController/Delete/5
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

        // GET: EstanteriaController/AddProducto
        [HttpGet]
        public ActionResult AddProducto(int idProducto)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            SessionInitialize();
            
            // Obtener producto
            var prodRepo = new ProductoRepository(session);
            var prodCEN = new ProductoCEN(prodRepo);
            var prodEN = prodCEN.ReadOID(idProducto);
            var prodVM = new ProductoAssembler().ConvertENToModelUI(prodEN);

            // Obtener estanterías del usuario
            var estRepo = new EstanteriaRepository(session);
            var estCEN = new EstanteriaCEN(estRepo);
            var estanterias = estCEN.ReadAll(0, -1)
                .Where(e => e.Usuario != null && e.Usuario.Email == u.email)
                .ToList();

            SessionClose();

            if (estanterias.Count == 0)
            {
                // Si no tiene estanterías, redirigir a crear una
                return RedirectToAction("Create");
            }

            ViewBag.Producto = prodVM;
            ViewBag.Estanterias = new SelectList(estanterias, "Id", "Descripcion");

            return View();
        }

        // POST: EstanteriaController/AddProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducto(int idEstanteria, int idProducto)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            try
            {
                SessionInitialize();
                var estRepo = new EstanteriaRepository(session);
                var estCEN = new EstanteriaCEN(estRepo);
                
                // Leer estantería actual
                var estEN = estCEN.ReadOID(idEstanteria);
                
                // Verificar que pertenece al usuario
                if (estEN.Usuario.Email != u.email)
                {
                    SessionClose();
                    return RedirectToAction("Index", "Home");
                }

                // Añadir producto a la lista existente usando la sesión abierta
                var prodRepo = new ProductoRepository(session);
                var prodEN = prodRepo.ReadOID(idProducto);
                
                if (!estEN.Producto.Contains(prodEN))
                {
                    estEN.Producto.Add(prodEN);
                    // Usar el repositorio para guardar cambios si no podemos acceder a session.Update directamente
                    // O castear session.CurrentSession a ISession
                    var nhSession = (NHibernate.ISession)session.CurrentSession;
                    nhSession.Update(estEN);
                    nhSession.Flush();
                }
                
                SessionClose();

                return RedirectToAction("EstanteriaVirtual", "Usuario");
            }
            catch (Exception ex)
            {
                try { SessionClose(); } catch { }
                ModelState.AddModelError("", ex.Message);
                
                // Recargar vista si falla
                return RedirectToAction("AddProducto", new { idProducto = idProducto });
            }
        }
    }
}
