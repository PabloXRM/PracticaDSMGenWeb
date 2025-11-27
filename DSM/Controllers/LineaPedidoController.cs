using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: LineaPedidoController
        public ActionResult Index()
        {
            SessionInitialize();
            LineaPedidoRepository repo = new LineaPedidoRepository(session);
            LineaPedidoCEN cen = new LineaPedidoCEN(repo);

            IList<LineaPedidoEN> listEN = cen.ReadAll(0, -1);

            IEnumerable<LineaPedidoViewModel> listVM =
                new LineaPedidoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listVM);
        }

        // GET: LineaPedidoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            LineaPedidoRepository repo = new LineaPedidoRepository(session);
            LineaPedidoCEN cen = new LineaPedidoCEN(repo);

            LineaPedidoEN en = cen.ReadOID(id);
            LineaPedidoViewModel vm = new LineaPedidoAssembler().ConvertENToModelUI(en);

            SessionClose();
            return View(vm);
        }

        // GET: LineaPedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaPedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LineaPedidoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                // Construir entidad con las tres propiedades solicitadas
                LineaPedidoEN linea = new LineaPedidoEN
                {
                    Cantidad = vm.Cantidad,
                    Precio = vm.Precio
                };

                // Guardar la línea usando el repositorio (firma existente)
                LineaPedidoRepository repo = new LineaPedidoRepository();
                repo.New_(linea);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // GET: LineaPedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            LineaPedidoRepository repo = new LineaPedidoRepository(session);
            LineaPedidoCEN cen = new LineaPedidoCEN(repo);

            LineaPedidoEN en = cen.ReadOID(id);
            LineaPedidoViewModel vm = new LineaPedidoAssembler().ConvertENToModelUI(en);

            SessionClose();
            return View(vm);
        }

        // POST: LineaPedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LineaPedidoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                LineaPedidoRepository repo = new LineaPedidoRepository();
                LineaPedidoCEN cen = new LineaPedidoCEN(repo);

                // Firma correcta: Modify(num, cantidad, precio)
                cen.Modify(vm.Num, vm.Cantidad, vm.Precio);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return View(vm);
            }
        }

        // GET: LineaPedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            LineaPedidoRepository repo = new LineaPedidoRepository();
            LineaPedidoCEN cen = new LineaPedidoCEN(repo);
            cen.Destroy(id);

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