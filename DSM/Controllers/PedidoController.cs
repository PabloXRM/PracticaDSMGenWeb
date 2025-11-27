using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: PedidoController
        public ActionResult Index()
        {
            SessionInitialize();
            PedidoRepository pedidoRepository = new PedidoRepository(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);

            IList<PedidoEN> listEN = pedidoCEN.ReadAll(0, -1);

            IEnumerable<PedidoViewModel> listVM =
                new PedidoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listVM);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PedidoRepository pedidoRepository = new PedidoRepository(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);

            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            PedidoViewModel pedidoView = new PedidoAssembler().ConvertENToModelUI(pedidoEN);

            SessionClose();

            return View(pedidoView);
        }

        // GET: PedidoController/Ver/5
        public ActionResult Ver(int id)
        {
            SessionInitialize();
            PedidoRepository pedidoRepository = new PedidoRepository(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);

            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            PedidoViewModel pedidoView = new PedidoAssembler().ConvertENToModelUI(pedidoEN);

            SessionClose();

            // Devolver explícitamente la vista "Ver"
            return View("Ver", pedidoView);
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            PopulateSelectLists();
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedido)
        {
            if (!ModelState.IsValid)
            {
                PopulateSelectLists(pedido);
                return View(pedido);
            }

            try
            {
                PedidoRepository pedidoRepo = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

                // Mapear Carrito ViewModel -> CarritoEnum (dominio)
                CarritoEnum carritoEN = CarritoEnum.vacio;
                if (pedido.Carrito.HasValue)
                {
                    carritoEN = pedido.Carrito.Value == Carrito.ConArticulos
                        ? CarritoEnum.conArticulos
                        : CarritoEnum.vacio;
                }

                // Valores por defecto para usuario/metodoPago (se aceptan null/-1 según implementación CEN)
                string usuarioPorDefecto = null;
                int metodoPagoPorDefecto = -1;

                pedidoCEN.New_(
                    usuarioPorDefecto,
                    metodoPagoPorDefecto,
                    carritoEN,
                    pedido.Numero,
                    pedido.Fecha,
                    pedido.TotalPrecio
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                PopulateSelectLists(pedido);
                return View(pedido);
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            PedidoRepository pedidoRepo = new PedidoRepository(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            PedidoViewModel pedidoView = new PedidoAssembler().ConvertENToModelUI(pedidoEN);

            SessionClose();
            PopulateSelectLists(pedidoView);
            return View(pedidoView);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            if (!ModelState.IsValid)
            {
                PopulateSelectLists(pedido);
                return View(pedido);
            }

            try
            {
                PedidoRepository pedidoRepo = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

                // Recuperamos el pedido actual de la BD
                PedidoEN actual = pedidoCEN.ReadOID(pedido.Id);

                if (actual == null)
                {
                    ModelState.AddModelError(string.Empty, "Pedido no encontrado.");
                    PopulateSelectLists(pedido);
                    return View(pedido);
                }

                // Mapear Carrito ViewModel -> CarritoEnum
                CarritoEnum carritoEN = CarritoEnum.vacio;
                if (pedido.Carrito.HasValue)
                {
                    carritoEN = pedido.Carrito.Value == Carrito.ConArticulos
                        ? CarritoEnum.conArticulos
                        : CarritoEnum.vacio;
                }
                else
                {
                    carritoEN = actual.Carrito;
                }

                // Mapear Estado ViewModel -> EstadoPedidoEnum
                EstadoPedidoEnum estadoEN = EstadoPedidoEnum.enProceso;
                if (pedido.EstadoPedido.HasValue)
                {
                    switch (pedido.EstadoPedido.Value)
                    {
                        case EstadoPedido.Pendiente:
                        case EstadoPedido.Confirmado:
                            estadoEN = EstadoPedidoEnum.enProceso;
                            break;
                        case EstadoPedido.Enviado:
                            estadoEN = EstadoPedidoEnum.enviado;
                            break;
                        case EstadoPedido.Entregado:
                            estadoEN = EstadoPedidoEnum.entregado;
                            break;
                        case EstadoPedido.Cancelado:
                            estadoEN = EstadoPedidoEnum.cancelado;
                            break;
                        default:
                            estadoEN = actual.EstadoPedido;
                            break;
                    }
                }
                else
                {
                    estadoEN = actual.EstadoPedido;
                }

                pedidoCEN.Modify(
                    pedido.Id,
                    carritoEN,
                    pedido.Numero,
                    pedido.Fecha,
                    pedido.TotalPrecio,
                    estadoEN
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                PopulateSelectLists(pedido);
                return View(pedido);
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            PedidoRepository pedidoRepo = new PedidoRepository(session);
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);

            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            PedidoViewModel pedidoView = new PedidoAssembler().ConvertENToModelUI(pedidoEN);

            SessionClose();
            return View(pedidoView);
        }

        // POST: PedidoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PedidoRepository pedidoRepo = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepo);
                pedidoCEN.Destroy(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        // Helper: llenar listas para selects
        private void PopulateSelectLists(PedidoViewModel model = null)
        {
            var carritoItems = Enum.GetValues(typeof(DSM.Models.Carrito))
                .Cast<DSM.Models.Carrito>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString(),
                    Selected = (model != null && model.Carrito.HasValue && model.Carrito.Value == e)
                }).ToList();

            var estadoItems = Enum.GetValues(typeof(DSM.Models.EstadoPedido))
                .Cast<DSM.Models.EstadoPedido>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString(),
                    Selected = (model != null && model.EstadoPedido.HasValue && model.EstadoPedido.Value == e)
                }).ToList();

            ViewBag.CarritoList = carritoItems;
            ViewBag.EstadoList = estadoItems;
        }
    }
}