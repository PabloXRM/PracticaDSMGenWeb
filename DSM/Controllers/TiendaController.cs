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
    public class TiendaController : BasicController
    {
        public ActionResult Catalogo()
        {
            SessionInitialize();

            var repo = new ProductoRepository(session);
            var cen = new ProductoCEN(repo);

            IList<ProductoEN> listEN = cen.ReadAll(0, -1);
            var listVM = new ProductoAssembler().ConvertListENToViewModel(listEN).ToList();

            SessionClose();
            return View(listVM);
        }

        public ActionResult Producto(int id)
        {
            var u = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            bool isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            SessionInitialize();

            var prodRepo = new ProductoRepository(session);
            var prodCEN = new ProductoCEN(prodRepo);
            var prodEN = prodCEN.ReadOID(id);

            if (prodEN == null)
            {
                SessionClose();
                return RedirectToAction("Catalogo");
            }

            var prodVM = new ProductoAssembler().ConvertENToModelUI(prodEN);

            var resRepo = new PracticaDSMGen.Infraestructure.Repository.PracticaDSM.ReseñaRepository(session);
            var resCEN = new ReseñaCEN(resRepo);

            var resenasEN = resCEN.ReadAll(0, -1)
                .Where(r => r.Producto != null && r.Producto.Id == id)
                .ToList();

            var resenasVM = new ResenaAssembler().ConvertListENToViewModel(resenasEN).ToList();

            SessionClose();

            var pageVM = new ProductoDetalleViewModel
            {
                Producto = prodVM,
                Resenas = resenasVM,
                UsuarioLogueado = (u != null),
                EsAdmin = isAdmin,
                PuedeResenar = (u != null && !isAdmin)
            };

            return View(pageVM);
        }
    }
}
