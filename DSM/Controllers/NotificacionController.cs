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



            SessionClose();

        }

        // GET: NotificacionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();


            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
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
        {
            {
            }

            SessionInitialize();
            try
            {


                return RedirectToAction(nameof(Index));
            }
            {
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();


            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        {
            {
            }

            SessionInitialize();
            try
            {


                return RedirectToAction(nameof(Index));
            }
            {
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
