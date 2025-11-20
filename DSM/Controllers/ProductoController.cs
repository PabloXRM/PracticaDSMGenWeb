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

namespace DSM.Controllers
{
    public class ProductoController : BasicController
    {
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
        public ActionResult Create(ProductoViewModel art)
        {
            if (!ModelState.IsValid)
            {
                // Hay errores de validación → volvemos a la vista mostrando mensajes
                return View(art);
            }

            try
            {
                ProductoRepository artRepo = new ProductoRepository();
                ProductoCEN artCEN = new ProductoCEN(artRepo);

                // Valores por defecto para los campos que no se piden en el formulario
                var formatoPorDefecto = FormatoEnum.cd;
                var estiloPorDefecto = EstiloEnum.pop;
                var fotoPorDefecto = "default.png";
                var artistaPorDefecto = "Artista desconocido";

                artCEN.New_(
                    art.Descripcion,
                    (decimal)art.Precio,
                    art.Stock,
                    formatoPorDefecto,
                    estiloPorDefecto,
                    fotoPorDefecto,
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
