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

            NotificacionEN en = notiCEN.ReadOID(id);
            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(vm);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {
            CargarTipos();   // m�todo auxiliar
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

            SessionInitialize();
            try
            {
                NotificacionRepository notiRepo = new NotificacionRepository();
                NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

                // TODO: call notiCEN.New_(...) with appropriate parameters

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                CargarTipos();
                return View(noti);
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            NotificacionRepository notiRepo = new NotificacionRepository(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

            NotificacionEN en = notiCEN.ReadOID(id);
            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
            CargarTipos();
            return View(vm);
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotificacionViewModel noti)
        {
            if (!ModelState.IsValid)
            {
                CargarTipos();
                return View(noti);
            }

            SessionInitialize();
            try
            {
                NotificacionRepository notiRepo = new NotificacionRepository();
                NotificacionCEN notiCEN = new NotificacionCEN(notiRepo);

                // TODO: call notiCEN.Modify(...) with appropriate parameters

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                CargarTipos();
                return View(noti);
            }
        }

        // GET: NotificacionController/Delete/5
        public ActionResult Delete(int id)
        {

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
