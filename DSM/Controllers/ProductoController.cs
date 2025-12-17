using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DSM.Filters;

namespace DSM.Controllers
{
    [AdminOnly]
    public class ProductoController : BasicController
    { 
        private readonly IWebHostEnvironment _webHost;

        public ProductoController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;

        }
        // GET: ProductoController
        public ActionResult Index()
        {
            SessionInitialize();
            ProductoRepository artRepository = new ProductoRepository(session);
            ProductoCEN artCEN = new ProductoCEN(artRepository);

            IList<ProductoEN> listEN = artCEN.ReadAll(0, -1);

            IEnumerable<ProductoViewModel> listArts =
                new ProductoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listArts);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ProductoRepository artRepository = new ProductoRepository(session);
            ProductoCEN artCEN = new ProductoCEN(artRepository);

            ProductoEN artEN = artCEN.ReadOID(id);
            ProductoViewModel artView = new ProductoAssembler().ConvertENToModelUI(artEN);

            SessionClose();

            return View(artView);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ProductoViewModel art)
        {
            // Validar que se ha proporcionado un archivo
            if (art.Fichero == null || art.Fichero.Length == 0)
            {
                ModelState.AddModelError(nameof(art.Fichero), "Debe seleccionar una imagen para el producto");
                return View(art);
            }

            string fileName = "", path = "";
            if (art.Fichero != null && art.Fichero.Length > 0)
            {
                fileName = Path.GetFileName(art.Fichero.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await art.Fichero.CopyToAsync(stream);
                }
            }

            try
            {
                fileName = "/Images/" + fileName;
                ProductoRepository artRepo = new ProductoRepository();
                ProductoCEN artCEN = new ProductoCEN(artRepo);

                // Valores por defecto para los campos que no se piden en el formulario
                var formatoPorDefecto = FormatoEnum.cd;
                var estiloPorDefecto = EstiloEnum.pop;
                var artistaPorDefecto = "Artista desconocido";

                artCEN.New_(
                    art.Descripcion,
                    (decimal)art.Precio,
                    art.Stock,
                    formatoPorDefecto,
                    estiloPorDefecto,
                    fileName,
                    artistaPorDefecto
                    
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Mostrar el error en la propia página
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(art);
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ProductoRepository artRepo = new ProductoRepository(session);
            ProductoCEN artCEN = new ProductoCEN(artRepo);

            ProductoEN artEN = artCEN.ReadOID(id);
            ProductoViewModel artView = new ProductoAssembler().ConvertENToModelUI(artEN);

            SessionClose();
            return View(artView);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel art)
        {
            if (!ModelState.IsValid)
            {
                return View(art);
            }

            try
            {
                ProductoRepository artRepo = new ProductoRepository();
                ProductoCEN artCEN = new ProductoCEN(artRepo);

                // Recuperamos el producto actual de la BD
                ProductoEN actual = artCEN.ReadOID(art.Id);

                // Si por algún motivo no existe, error
                if (actual == null)
                {
                    ModelState.AddModelError(string.Empty, "Producto no encontrado.");
                    return View(art);
                }

                // Usamos los valores de la BD para los campos que no se editan en el formulario
                artCEN.Modify(
                    art.Id,
                    art.Descripcion,
                    (decimal)art.Precio,
                    art.Stock,
                    actual.Formato,
                    actual.Estilo,
                    actual.Fotos,
                    actual.Artista
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ModelState.AddModelError(string.Empty, msg);
                return View(art);
            }
        }


        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoRepository artRepo = new ProductoRepository();
            ProductoCEN artCEN = new ProductoCEN(artRepo);
            artCEN.Destroy(id);


            return RedirectToAction(nameof(Index));
        }

        // POST: ProductoController/Delete/5
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
