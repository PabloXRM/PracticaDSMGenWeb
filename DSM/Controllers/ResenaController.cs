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

namespace DSM.Controllers
{
    public class ResenaController : BasicController
    {
        // GET: ResenaController
        public ActionResult Index()
        {
            SessionInitialize();
            var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository(session);
            var cen = new ReseñaCEN(repo);
            IList<ReseñaEN> listEN = cen.ReadAll(0, -1);
            var listVM = new ResenaAssembler().ConvertListENToViewModel(listEN).ToList();
            SessionClose();
            return View(listVM);
        }

        // GET: ResenaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository(session);
            var cen = new ReseñaCEN(repo);
            var en = cen.ReadOID(id);
            var vm = new ResenaAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(vm);
        }

        // GET: ResenaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResenaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResenaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository();
                var cen = new ReseñaCEN(repo);
                cen.New_(model.UsuarioEmail ?? "", model.ProductoId, model.Descripcion, model.Nota, model.Fecha);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // GET: ResenaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository(session);
            var cen = new ReseñaCEN(repo);
            var en = cen.ReadOID(id);
            var vm = new ResenaAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(vm);
        }

        // POST: ResenaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResenaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository();
                var cen = new ReseñaCEN(repo);
                cen.Modify(model.Id, model.Descripcion, model.Nota, model.Fecha);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // GET: ResenaController/Delete/5
        public ActionResult Delete(int id)
        {
            var repo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository();
            var cen = new ReseñaCEN(repo);
            cen.Destroy(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
