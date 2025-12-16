using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using DSM.Filters;


namespace DSM.Controllers
{
    [AdminOnly]
    public class FacturaController : BasicController
    {
        // GET: FacturaController
        public ActionResult Index()
        {
            SessionInitialize();
            FacturaRepository facRepository = new FacturaRepository(session);
            FacturaCEN facCEN = new FacturaCEN(facRepository);

            IList<FacturaEN> listEN = facCEN.ReadAll(0, -1);

            IEnumerable<FacturaViewModel> listArts =
                new FacturaAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listArts);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            FacturaRepository facRepo = new FacturaRepository(session);
            FacturaCEN facCEN = new FacturaCEN(facRepo);

            FacturaEN facEN = facCEN.ReadOID(id);
            FacturaViewModel facView = new FacturaAssembler().ConvertENToModelUI(facEN);

            SessionClose();
            return View(facView);
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel fac)
        {
            if (!ModelState.IsValid)
            {
                // Hay errores de validación → volvemos a la vista mostrando mensajes
                return View(fac);
            }

            try
            {
                FacturaRepository facRepo = new FacturaRepository();
                FacturaCEN facCEN = new FacturaCEN(facRepo);

                /* Valores por defecto para los campos que no se piden en el formulario
                var valoracionPorDefecto = "0/10";
                var visitasPorDefecto = 0;
                var visibilidadPorDefecto = true;
                */

                //No quiero introducir valoracion, visitas y visibilidad, quiero que sea default
                facCEN.New_(
                   00001,  //Recuperar id de un pedido??
                   fac.Numero,
                   fac.ImporteTotal,
                   fac.Fecha
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Mostrar el error en la propia página
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(fac);
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            FacturaRepository facRepo = new FacturaRepository(session);
            FacturaCEN facCEN = new FacturaCEN(facRepo);

            FacturaEN facEN = facCEN.ReadOID(id);
            FacturaViewModel facView = new FacturaAssembler().ConvertENToModelUI(facEN);

            SessionClose();
            return View(facView);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel fac)
        {
            if (!ModelState.IsValid)
            {
                return View(fac);
            }

            try
            {
                FacturaRepository facRepo = new FacturaRepository();
                FacturaCEN facCEN = new FacturaCEN(facRepo);

                // Usamos los valores de la BD para los campos que no se editan en el formulario
                facCEN.Modify(
                fac.Id,
                fac.Numero,
                fac.ImporteTotal,
                fac.Fecha
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(fac);
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            FacturaRepository facRepo = new FacturaRepository();
            FacturaCEN facCEN = new FacturaCEN(facRepo);
            facCEN.Destroy(id);


            return RedirectToAction(nameof(Index));
        }

        // POST: FacturaController/Delete/5
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
