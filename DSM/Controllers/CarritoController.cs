using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
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
            var metodos = mpCEN.ReadAll(0, -1);
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

                pedidoCEN.New_(u.email, metodoPagoId, CarritoEnum.conArticulos, numero, fecha, total);

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
                var metodos = mpCEN.ReadAll(0, -1);
                SessionClose();
                ViewBag.MetodosPago = new SelectList(metodos, "Id", "Tipo");

                return View();
            }
        }
    }

    public class CarritoItemViewModel
    {
        public ProductoViewModel Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
