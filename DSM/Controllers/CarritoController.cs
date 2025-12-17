using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Controllers
{
    public class CarritoController : BasicController
    {
        // POST: /Carrito/Add
        [HttpPost]
        public ActionResult Add(int id)
        {
            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            cart[id] = cart.ContainsKey(id) ? cart[id] + 1 : 1;
            HttpContext.Session.Set("cart", cart);

            return RedirectToAction("Index");
        }

        // GET: /Carrito/AñadirAlCarrito (para enlaces desde vista)
        [HttpGet]
        public ActionResult AñadirAlCarrito(int id)
        {
            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            cart[id] = cart.ContainsKey(id) ? cart[id] + 1 : 1;
            HttpContext.Session.Set("cart", cart);

            return RedirectToAction("Index");
        }

        // GET: /Carrito
        public ActionResult Index()
        {
            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();

            SessionInitialize();
            var repo = new ProductoRepository(session);
            var cen = new ProductoCEN(repo);
            var listEN = cen.ReadAll(0, -1);
            SessionClose();

            var productos = new ProductoAssembler().ConvertListENToViewModel(listEN).ToList();

            var items = productos
                .Where(p => cart.ContainsKey(p.Id))
                .Select(p => new CarritoItemViewModel
                {
                    Producto = p,
                    Cantidad = cart[p.Id]
                })
                .ToList();

            return View(items);
        }

        // POST: /Carrito/Remove
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            if (cart.ContainsKey(id))
            {
                cart.Remove(id);
                HttpContext.Session.Set("cart", cart);
            }
            return RedirectToAction("Index");
        }

        // POST: /Carrito/Clear
        [HttpPost]
        public ActionResult Clear()
        {
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index");
        }

        // GET: /Carrito/Checkout
        [HttpGet]
        public ActionResult Checkout()
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            if (cart.Count == 0) return RedirectToAction("Index");

            SessionInitialize();
            var mpRepo = new MetodoPagoRepository(session);
            var mpCEN = new MetodoPagoCEN(mpRepo);
            var metodos = mpCEN.ReadAll(0, -1).Where(m => m.Valido).ToList();
            SessionClose();

            ViewBag.MetodosPago = new SelectList(metodos, "Id", "Tipo");
            return View();
        }

        // POST: /Carrito/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(int metodoPagoId)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", " Usuario");

            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            if (cart.Count == 0) return RedirectToAction("Index");

            SessionInitialize();
            var prodRepo = new ProductoRepository(session);
            var prodCEN = new ProductoCEN(prodRepo);
            var productos = prodCEN.ReadAll(0, -1).ToList();
            SessionClose();

            decimal total = 0m;
            foreach (var kv in cart)
            {
                var prod = productos.FirstOrDefault(p => p.Id == kv.Key);
                if (prod != null)
                {
                    var precio = prod.Precio;
                    total += precio * kv.Value;
                }
            }

            try
            {
                var pedidoRepo = new PedidoRepository();
                var pedidoCEN = new PedidoCEN(pedidoRepo);

                var numero = "PED-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                var fecha = DateTime.Now;

                // Inicializar pedido con precio 0, ya que LineaPedidoCP sumará el precio de las líneas
                int idPedido = pedidoCEN.New_(u.email, metodoPagoId, CarritoEnum.conArticulos, numero, fecha, 0);

                // Crear líneas de pedido para cada producto en el carrito
                SessionInitialize();
                var lineaPedidoCP = new PracticaDSMGen.ApplicationCore.CP.PracticaDSM.LineaPedidoCP(
                    new PracticaDSMGen.Infraestructure.CP.SessionCPNHibernate());
                
                int lineNumber = 1;
                foreach (var kv in cart)
                {
                    var prod = productos.FirstOrDefault(p => p.Id == kv.Key);
                    if (prod != null)
                    {
                        // Usar decimal para precio, no castear a int
                        decimal precioLinea = prod.Precio * kv.Value;
                        // New_ signature: (int p_pedido, int p_cantidad, int p_producto, decimal p_precio)
                        // p_precio is total price of the line
                        lineaPedidoCP.New_(idPedido, kv.Value, kv.Key, precioLinea);
                        lineNumber++;
                    }
                }
                SessionClose();

                // Enviar el pedido para decrementar stock
                var pedidoCP = new PracticaDSMGen.ApplicationCore.CP.PracticaDSM.PedidoCP(
                    new PracticaDSMGen.Infraestructure.CP.SessionCPNHibernate());
                pedidoCP.EnviarPedido(idPedido);

                // Crear factura automáticamente
                SessionInitialize();
                var facturaRepo = new FacturaRepository(session);
                var facturaCEN = new FacturaCEN(facturaRepo);
                
                string numeroFactura = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                facturaCEN.New_(idPedido, numeroFactura, total, DateTime.Now);
                
                SessionClose();

                HttpContext.Session.Remove("cart");
                return RedirectToAction("Index", "Pedido");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                // Repoblar ViewBag.MetodosPago antes de devolver la vista para evitar fallos al renderizar.
                SessionInitialize();
                var mpRepo = new MetodoPagoRepository(session);
                var mpCEN = new MetodoPagoCEN(mpRepo);
                var metodos = mpCEN.ReadAll(0, -1).Where(m => m.Valido).ToList();
                SessionClose();
                ViewBag.MetodosPago = new SelectList(metodos, "Id", "Tipo");

                return View();
            }
        }

        // POST: /Carrito/UpdateCantidad
        [HttpPost]
        public ActionResult UpdateCantidad(int id, int cantidad)
        {
            var cart = HttpContext.Session.Get<Dictionary<int, int>>("cart") ?? new Dictionary<int, int>();
            
            if (cantidad <= 0)
            {
                // Si cantidad es 0 o negativa, quitar el producto
                cart.Remove(id);
            }
            else
            {
                cart[id] = cantidad;
            }
            
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("Index");
        }

        // GET: /Carrito
    }

    public class CarritoItemViewModel
    {
        public ProductoViewModel Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
