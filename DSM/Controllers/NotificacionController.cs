// NotificacionController.cs
using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSM.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: NotificacionController
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionRepository notiRepo = new NotificacionRepository(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

            IList<NotificacionEN> listEN = notiCEN.ReadAll(0, -1);

            IEnumerable<NotificacionViewModel> list =
                new NotificacionAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(list);
        }

        // GET: NotificacionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            NotificacionRepository notiRepo = new NotificacionRepository(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

            NotificacionEN notiEN = notiCEN.ReadOID(id);
            NotificacionViewModel notiView = new NotificacionAssembler().ConvertENToModelUI(notiEN);

            SessionClose();

            return View(notiView);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {
            CargarTipos();   // método auxiliar
            return View();
        }

        private void CargarTipos()
        {
            var tipos = Enum.GetValues(typeof(TipoNotificacionEnum))
                            .Cast<TipoNotificacionEnum>()
                            .Select(t => new SelectListItem
                            {
                                Value = t.ToString(),
                                Text = t.ToString()
                            });

            ViewBag.Tipos = tipos;
        }


        // POST: NotificacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotificacionViewModel noti)
        {
            if (!ModelState.IsValid)
            {
                CargarTipos();
                return View(noti);
            }

            try
            {
                NotificacionRepository notiRepo = new NotificacionRepository();
                NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

                string emailUsuario = "cliente@demo.com";
                DateTime? fecha = noti.Fecha ?? DateTime.Now;

                notiCEN.New_(
                    emailUsuario,
                    noti.Tipo,        // ← valor del SELECT
                    fecha,
                    noti.Titulo,
                    noti.Descripcion,
                    noti.Fotos
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(noti);
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            NotificacionRepository notiRepo = new NotificacionRepository(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

            NotificacionEN notiEN = notiCEN.ReadOID(id);
            NotificacionViewModel notiView = new NotificacionAssembler().ConvertENToModelUI(notiEN);

            SessionClose();
            return View(notiView);
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotificacionViewModel noti)
        {
            if (!ModelState.IsValid)
            {
                return View(noti);
            }

            try
            {
                NotificacionRepository notiRepo = new NotificacionRepository();
                NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);


                notiCEN.Modify(
                    noti.Id,
                    noti.Tipo,
                    noti.Fecha,
                    noti.Titulo,
                    noti.Descripcion,
                    noti.Fotos
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(noti);
            }
        }

        // GET: NotificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            NotificacionRepository notiRepo = new NotificacionRepository();
            NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);
            notiCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: NotificacionController/Delete/5
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
