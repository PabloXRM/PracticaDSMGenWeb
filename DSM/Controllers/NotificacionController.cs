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
    public class NotificacionController : BasicController
    {
        // GET: NotificacionController
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionRepository repo = new NotificacionRepository(session);
            NotificacionCEN cen = new NotificacionCEN(repo);

            IList<NotificacionEN> listEN = cen.ReadAll(0, -1);

            IEnumerable<NotificacionViewModel> listVM = new NotificacionAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();

            return View(listVM);
        }

        // GET: NotificacionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            NotificacionRepository repo = new NotificacionRepository(session);
            NotificacionCEN cen = new NotificacionCEN(repo);

            NotificacionEN en = cen.ReadOID(id);
            if (en == null)
            {
                SessionClose();
                return RedirectToAction(nameof(Index));
            }

            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(vm);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotificacionViewModel vm)
        {
            if (!ModelState.IsValid || vm == null)
            {
                return View(vm);
            }

            SessionInitialize();
            try
            {
                NotificacionRepository repo = new NotificacionRepository(session);
                NotificacionCEN cen = new NotificacionCEN(repo);

                cen.New_(null, vm.Tipo, vm.Fecha, vm.Titulo, vm.Descripcion, vm.Fotos);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return View(vm);
            }
            finally
            {
                SessionClose();
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            NotificacionRepository repo = new NotificacionRepository(session);
            NotificacionCEN cen = new NotificacionCEN(repo);

            NotificacionEN en = cen.ReadOID(id);
            if (en == null)
            {
                SessionClose();
                return RedirectToAction(nameof(Index));
            }

            NotificacionViewModel vm = new NotificacionAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(vm);
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotificacionViewModel vm)
        {
            if (!ModelState.IsValid || vm == null)
            {
                return View(vm);
            }

            SessionInitialize();
            try
            {
                NotificacionRepository repo = new NotificacionRepository(session);
                NotificacionCEN cen = new NotificacionCEN(repo);

                cen.Modify(vm.Id, vm.Tipo, vm.Fecha, vm.Titulo, vm.Descripcion, vm.Fotos);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return View(vm);
            }
            finally
            {
                SessionClose();
            }
        }

        // GET: NotificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            NotificacionRepository repo = new NotificacionRepository(session);
            NotificacionCEN cen = new NotificacionCEN(repo);
            cen.Destroy(id);
            SessionClose();

            return RedirectToAction(nameof(Index));
        }

        // POST: NotificacionController/Delete/5
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
