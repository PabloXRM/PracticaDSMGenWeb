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

namespace DSM.Controllers
{
    public class EstanteriaController : BasicController
    {
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
            return View();
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
            if (!ModelState.IsValid)
            {
                // Hay errores de validación → volvemos a la vista mostrando mensajes
                return View(est);
            }

            try
            {
                EstanteriaRepository estRepo = new EstanteriaRepository();
                EstanteriaCEN estCEN = new EstanteriaCEN(estRepo);

                // Valores por defecto para los campos que no se piden en el formulario
                var valoracionPorDefecto = "0/10";
                var visitasPorDefecto = 0;
                var visibilidadPorDefecto = true;
                
                //No quiero introducir valoracion, visitas y visibilidad, quiero que sea default
                estCEN.New_(
                    null,
                    null,
                    est.Descripcion,
                    est.Valoracion,
                    est.Visitas,
                    est.Visible
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Mostrar el error en la propia página
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(est);
            }
        }

        // GET: EstanteriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstanteriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EstanteriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}
