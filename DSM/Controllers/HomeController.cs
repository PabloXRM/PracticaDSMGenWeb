using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Portada (sin resultados)
        public IActionResult Index()
        {
            var vm = new HomeIndexViewModel();

            try
            {
                var productoCEN = new ProductoCEN(new ProductoRepository());
                IList<ProductoEN> todosProductos = productoCEN.ReadAll(0, 999999);

                if (todosProductos != null && todosProductos.Count > 0)
                {
                    // Seleccionar dos productos aleatorios como recomendaciones
                    var random = new Random();
                    var productosAleatorios = todosProductos
                        .OrderBy(x => random.Next())
                        .Take(2)
                        .ToList();

                    vm.ProductosRecomendados = new List<ProductoViewModel>();
                    foreach (var prod in productosAleatorios)
                    {
                        vm.ProductosRecomendados.Add(new ProductoAssembler().ConvertENToModelUI(prod));
                    }
                }
            }
            catch
            {
                // Si hay error al cargar recomendaciones, continuar sin ellas
            }

            return View(vm);
        }

        // Página nueva: resultados del buscador
        public IActionResult Resultados(string? q, EstiloEnum? estilo, FormatoEnum? formato)
        {
            var vm = GetProductosFiltrados(q, estilo, formato);
            return View(vm); // Views/Home/Resultados.cshtml
        }

        // ---- Lógica común de filtrado ----
        private HomeIndexViewModel GetProductosFiltrados(string? q, EstiloEnum? estilo, FormatoEnum? formato)
        {
            var productoCEN = new ProductoCEN(new ProductoRepository());

            // OJO: usa un número grande (en muchos CEN, -1 no devuelve todo)
            IList<ProductoEN> productosEN = productoCEN.ReadAll(0, 999999);

            var productosVM = new List<ProductoViewModel>();
            foreach (var p in productosEN)
                productosVM.Add(new ProductoAssembler().ConvertENToModelUI(p));

            if (!string.IsNullOrWhiteSpace(q))
            {
                var term = q.Trim().ToLowerInvariant();
                productosVM = productosVM.Where(p =>
                       (p.Descripcion ?? "").ToLowerInvariant().Contains(term)
                    || (p.Artista ?? "").ToLowerInvariant().Contains(term)
                ).ToList();
            }

            if (estilo.HasValue)
                productosVM = productosVM.Where(p => p.Estilo == estilo.Value).ToList();

            if (formato.HasValue)
                productosVM = productosVM.Where(p => p.Formato == formato.Value).ToList();

            return new HomeIndexViewModel
            {
                Q = q,
                Estilo = estilo,
                Formato = formato,
                Productos = productosVM
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
