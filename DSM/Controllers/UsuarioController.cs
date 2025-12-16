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

                // Rol por defecto SIEMPRE
                usuVM.Rol = "Usuario";
                usuVM.IdAdmin = null;

                //  Admin “fijo” por email (para tu caso)
                if (login.DNI.Trim().ToLower() == "prueba@gmail.com")
                {
                    usuVM.Rol = "Admin";
                }

                // 2) Detectar si también es Admin (por tabla Admin)
                try
                {
                    //  usar la misma session
                    AdminRepository adminRepo = new AdminRepository(session);
                    AdminCEN adminCEN = new AdminCEN(adminRepo);

                    AdminEN adminEN = adminCEN.ReadOID(login.DNI);

                    //  NO dependemis de IdAdmin (puede venir vacío)
                    if (adminEN != null)
                    {
                        usuVM.Rol = "Admin";
                        usuVM.IdAdmin = adminEN.IdAdmin; // si viene null no pasa nada
                    }
                }
                catch { }

                // 2.5) Guardar flag rápido para filtros/menú
                HttpContext.Session.SetString("IsAdmin", (usuVM.Rol == "Admin") ? "true" : "false");

                // 3) Guardar en sesión
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                SessionClose();
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuarioController/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterUsuarioViewModel());
        }

        // POST: UsuarioController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                // Abrir sesión NHibernate (igual que haces en Login)
                SessionInitialize();

                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                // Crear usuario normal (perfil = null)
                // Firma esperada: New_(email, nombre, perfil, direccion, fechaNacimiento, codPostal, pass)
                usuCEN.New_(
                    model.Email,
                    model.Nombre,
                    null,
                    model.Direccion,
                    model.FechaNacimiento,
                    model.CodPostal,
                    model.Password
                );

                // Cargar el usuario recién creado y guardarlo en sesión como logueado
                UsuarioEN usuEN = usuCEN.ReadOID(model.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

                // Asegurar rol por defecto
                usuVM.Rol = "Usuario";
                usuVM.IdAdmin = null;

                HttpContext.Session.SetString("IsAdmin", "false");
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                SessionClose();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                try { SessionClose(); } catch { }

                // Muy común: email duplicado o restricción de BD
                ModelState.AddModelError("", "No se pudo crear el usuario. Puede que el email ya exista o los datos no sean válidos.");
                return View(model);
            }
        }

        // GET: UsuarioController/Perfil
        public ActionResult Perfil()
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null)
                return RedirectToAction("Login", "Usuario");

            try
            {
                SessionInitialize();

             
                string email = u.email; 

                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                UsuarioEN usuEN = usuCEN.ReadOID(email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

                // Mantener rol/idAdmin que ya detectaste al login
                usuVM.Rol = u.Rol;
                usuVM.IdAdmin = u.IdAdmin;

                SessionClose();
                return View(usuVM); // Views/Usuario/Perfil.cshtml
            }
            catch
            {
                try { SessionClose(); } catch { }
                return RedirectToAction("Login", "Usuario");
            }
        }

        // GET: UsuarioController/EditPerfil
        [HttpGet]
        public ActionResult EditPerfil()
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            try
            {
                SessionInitialize();

                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                UsuarioEN usuEN = usuCEN.ReadOID(u.email); // si tu propiedad es Email, usa u.Email

                var vm = new EditPerfilViewModel
                {
                    Email = usuEN.Email,
                    Nombre = usuEN.Nombre,
                    Direccion = usuEN.Direccion,
                    FechaNacimiento = usuEN.FechaNacimiento ?? DateTime.MinValue,
                    CodPostal = usuEN.CodPostal
                };

                SessionClose();
                return View(vm);
            }
            catch
            {
                try { SessionClose(); } catch { }
                return RedirectToAction("Perfil", "Usuario");
            }
        }

        // POST: UsuarioController/EditPerfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerfil(EditPerfilViewModel model)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                SessionInitialize();

                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                // Guardar cambios en BD (tu firma real)
                usuCEN.Modify(
                    model.Email,
                    model.Nombre,
                    model.Direccion,
                    model.FechaNacimiento,
                    model.CodPostal
                );

                // Recargar datos y actualizar sesión
                UsuarioEN usuEN = usuCEN.ReadOID(model.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

                // Mantener rol/admin que ya tenías
                usuVM.Rol = u.Rol;
                usuVM.IdAdmin = u.IdAdmin;

                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                SessionClose();
                return RedirectToAction("Perfil", "Usuario");
            }
            catch
            {
                try { SessionClose(); } catch { }
                ModelState.AddModelError("", "No se pudieron guardar los cambios.");
                return View(model);
            }
        }

        // GET: UsuarioController/CambiarPassword
        [HttpGet]
        public ActionResult CambiarPassword()
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            return View(new ChangePasswordViewModel());
        }

        // POST: UsuarioController/CambiarPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarPassword(ChangePasswordViewModel model)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (u == null) return RedirectToAction("Login", "Usuario");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                SessionInitialize();

                var usuRepo = new UsuarioRepository();
                var usuCEN = new UsuarioCEN(usuRepo);

                // 1) Verificar contraseña actual
                if (usuCEN.Login(u.email, model.PasswordActual) == null) // si es u.Email, cambia aquí
                {
                    ModelState.AddModelError("", "La contraseña actual no es correcta.");
                    SessionClose();
                    return View(model);
                }

                // 2) Cambiar contraseña (operación nueva en CEN/Repository)
                usuCEN.ChangePassword(u.email, model.PasswordNueva);

                SessionClose();
                return RedirectToAction("Perfil", "Usuario");
            }
            catch
            {
                try { SessionClose(); } catch { }
                ModelState.AddModelError("", "No se pudo cambiar la contraseña.");
                return View(model);
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

        // GET: UsuarioController/Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login", "Usuario");
        }

    }
}
