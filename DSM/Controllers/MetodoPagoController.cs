using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using DSM.Filters;

namespace DSM.Controllers
{
    public class MetodoPagoController : BasicController
    {
        // GET: MetodoPagoController
        [AdminOnly]
        public ActionResult Index()
        {
            SessionInitialize();
            MetodoPagoRepository metRepository = new MetodoPagoRepository(session);
            MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepository);

            IList<MetodoPagoEN> listEN = metCEN.ReadAll(0, -1);

            IEnumerable<MetodoPagoViewModel> listArts =
                new MetodoPagoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listArts);
        }

        // GET: MetodoPagoController/Details/5
        [AdminOnly]
        public ActionResult Details(int id)
        {
            SessionInitialize();
            MetodoPagoRepository metRepo = new MetodoPagoRepository(session);
            MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepo);

            MetodoPagoEN metEN = metCEN.ReadOID(id);
            MetodoPagoViewModel metView = new MetodoPagoAssembler().ConvertENToModelUI(metEN);

            SessionClose();
            return View(metView);
        }

        // GET: MetodoPagoController/Create
        [AdminOnly]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Create(MetodoPagoViewModel met)
        {
            if (!ModelState.IsValid)
            {
                return View(met);
            }

            try
            {
                MetodoPagoRepository metRepo = new MetodoPagoRepository();
                MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepo);

                // Los administradores deben proporcionar el tipo de pago
                metCEN.New_(
                   "admin@sistema.local",  // Usuario admin del sistema
                   met.TipoPago,
                   met.Valido
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex.Message);
                return View(met);
            }
        }

        // GET: MetodoPagoController/Edit/5
        [AdminOnly]
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            MetodoPagoRepository metRepo = new MetodoPagoRepository(session);
            MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepo);

            MetodoPagoEN metEN = metCEN.ReadOID(id);
            MetodoPagoViewModel metView = new MetodoPagoAssembler().ConvertENToModelUI(metEN);

            SessionClose();
            return View(metView);
        }

        // POST: MetodoPagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Edit(MetodoPagoViewModel met)
        {
            if (!ModelState.IsValid)
            {
                return View(met);
            }

            try
            {
                MetodoPagoRepository metRepo = new MetodoPagoRepository();
                MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepo);

                metCEN.Modify(
                met.Id,
                met.TipoPago,
                met.Valido
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(met);
            }
        }

        // GET: MetodoPagoController/Delete/5
        [AdminOnly]
        public ActionResult Delete(int id)
        {
            MetodoPagoRepository metRepo = new MetodoPagoRepository();
            MetodoPagoCEN metCEN = new MetodoPagoCEN(metRepo);
            metCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: MetodoPagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
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
