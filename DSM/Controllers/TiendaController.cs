using DSM.Assemblers;
using DSM.Models;
using Microsoft.AspNetCore.Mvc;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

//LO MISMO QUE EL PRODUCTO CONTROLLER PERO SIN RESTRICCION DE ADMIN
namespace DSM.Controllers
{
    public class TiendaController : BasicController
    {
        // GET: /Tienda/Catalogo
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

        // GET: /Tienda/Producto/5
        public ActionResult Producto(int id)
        {
            SessionInitialize();

            var repo = new ProductoRepository(session);
            var cen = new ProductoCEN(repo);

            ProductoEN en = cen.ReadOID(id);

            SessionClose();

            if (en == null) return NotFound();

            var vm = new ProductoAssembler().ConvertENToModelUI(en);
            return View(vm);
        }
    }
}
