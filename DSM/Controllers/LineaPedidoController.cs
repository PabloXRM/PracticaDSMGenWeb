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

            LineaPedidoEN lpEN = lpCEN.ReadOID(id);
            LineaPedidoViewModel lpView = new LineaPedidoAssembler().ConvertENToModelUI(lpEN);

            SessionClose();

            return View(lpView);
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
                SessionInitialize();
                PedidoRepository pedRepo = new PedidoRepository(session);
                PedidoCEN pedCEN = new PedidoCEN(pedRepo);
                var pedidos = pedCEN.ReadAll(0, -1);
                ViewBag.Pedidos = new SelectList(pedidos, "Id", "Id");
                SessionClose();

                return View(lp);
            }

            try
            {
                LineaPedidoRepository lpRepo = new LineaPedidoRepository();

                LineaPedidoEN lpEN = new LineaPedidoEN();
                lpEN.Cantidad = lp.Cantidad;
                lpEN.Precio = (decimal)lp.Precio;
                lpEN.Pedido = new PedidoEN { Id = lp.IdPedido }; // valor del SELECT

                lpRepo.New_(lpEN);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(lp);
            }
        }

        // GET: LineaPedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            LineaPedidoRepository lpRepo = new LineaPedidoRepository(session);
            LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);

            LineaPedidoEN lpEN = lpCEN.ReadOID(id);
            LineaPedidoViewModel lpView = new LineaPedidoAssembler().ConvertENToModelUI(lpEN);

            SessionClose();
            return View(lpView);
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

                // Firma típica: Modify(int p_LineaPedido_OID, int p_cantidad, decimal p_precio)
                lpCEN.Modify(
                    lp.Num,
                    lp.Cantidad,
                    (decimal)lp.Precio
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(lp);
            }
        }

        // GET: LineaPedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            LineaPedidoRepository lpRepo = new LineaPedidoRepository();
            LineaPedidoCEN lpCEN = new LineaPedidoCEN(lpRepo);
            lpCEN.Destroy(id);

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
