using DSM; // <-- para que reconozca SessionExtensions
using DSM.Models;
using DSM.Assemblers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Impl;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DSM.Controllers
{
    public class UsuarioController : BasicController
    {

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.DNI, login.Password) == null)
            {
                ModelState.AddModelError("", "DNI o contraseña incorrectos");
                return View();
            }
            else
            {
                SessionInitialize();

                // 1) Cargar usuario normal
                UsuarioEN usuEN = usuCEN.ReadOID(login.DNI);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

                // 2) Detectar si también es Admin (mismo OID: email/DNI)
                try
                {
                    AdminRepository adminRepo = new AdminRepository();
                    AdminCEN adminCEN = new AdminCEN(adminRepo);

                    AdminEN adminEN = adminCEN.ReadOID(login.DNI);

                    if (adminEN != null && !string.IsNullOrEmpty(adminEN.IdAdmin))
                    {
                        usuVM.Rol = "Admin";
                        usuVM.IdAdmin = adminEN.IdAdmin;
                    }
                }
                catch
                {
                    // Si no existe como Admin o falla, se queda como Usuario
                }

                // 3) Guardar en sesión
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                SessionClose();
                return RedirectToAction("Index", "Home");
            }
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
