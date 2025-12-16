using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
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

            // Montar vista: productos del carrito
            var productos = new ProductoAssembler().ConvertListENToViewModel(listEN).ToList();
            var items = productos
                .Where(p => cart.ContainsKey(p.Id))
                .Select(p => new CarritoItemViewModel
                {
                    Producto = p,
                    Cantidad = cart[p.Id]
                }).ToList();

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
    }

    public class CarritoItemViewModel
    {
        public ProductoViewModel Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
