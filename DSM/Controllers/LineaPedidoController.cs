// LineaPedidoController.cs
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
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedidoController
        public ActionResult Index()
        {
            SessionInitialize();
            LineaPedidoRepository lpRepo = new LineaPedidoRepository(session);
            LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

            IList<LineaPedidoEN> listEN = lpCEN.ReadAll(0, -1);

            IEnumerable<LineaPedidoViewModel> list =
                new LineaPedidoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(list);
        }

        // GET: LineaPedidoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            LineaPedidoRepository lpRepo = new LineaPedidoRepository(session);
            LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

            LineaPedidoEN en = lpCEN.ReadOID(id);
            LineaPedidoViewModel vm = new LineaPedidoAssembler().ConvertENToModelUI(en);

            SessionClose();
            return View(vm);
        }

        // GET: LineaPedidoController/Create
        public ActionResult Create()
        {
            SessionInitialize();
            PedidoRepository pedRepo = new PedidoRepository(session);
            PedidoCEN pedCEN = new PedidoCEN(pedRepo);
            var pedidos = pedCEN.ReadAll(0, -1);

            ViewBag.Pedidos = new SelectList(pedidos, "Id", "Fecha");
            SessionClose();

            return View();
        }


        // POST: LineaPedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LineaPedidoViewModel lp)
        {
            if (!ModelState.IsValid)
            {
                return View(lp);
            }

            try
            {
                LineaPedidoRepository lpRepo = new LineaPedidoRepository();
                LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

                // TODO: call lpCEN.New_(...) with appropriate parameters

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(lp);
            }
        }

        // GET: LineaPedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            LineaPedidoRepository lpRepo = new LineaPedidoRepository(session);
            LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

            LineaPedidoEN en = lpCEN.ReadOID(id);
            LineaPedidoViewModel vm = new LineaPedidoAssembler().ConvertENToModelUI(en);

            SessionClose();
            return View(vm);
        }

        // POST: LineaPedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LineaPedidoViewModel lp)
        {
            if (!ModelState.IsValid)
            {
                return View(lp);
            }

            try
            {
                LineaPedidoRepository lpRepo = new LineaPedidoRepository();
                LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

                // TODO: call lpCEN.Modify(...) with appropriate parameters

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(lp);
            }
        }

        // GET: LineaPedidoController/Delete/5
        public ActionResult Delete(int id)
        {

            return RedirectToAction(nameof(Index));
        }

        // POST: LineaPedidoController/Delete/5
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