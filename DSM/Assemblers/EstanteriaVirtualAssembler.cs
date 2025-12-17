using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Assemblers
{
    public class EstanteriaVirtualAssembler
    {
        public EstanteriaVirtualViewModel ConvertENToModelUI(EstanteriaEN en)
        {
            if (en == null) return null;

            var vm = new EstanteriaVirtualViewModel
            {
                Id = en.Id,
                Descripcion = en.Descripcion,
                Valoracion = en.Valoracion,
                Visitas = en.Visitas,
                Visible = en.Visible,
                Productos = new List<ProductoViewModel>()
            };

            // Mapear productos si existen
            if (en.Producto != null && en.Producto.Count > 0)
            {
                var productoAssembler = new ProductoAssembler();
                vm.Productos = en.Producto
                    .Select(p => productoAssembler.ConvertENToModelUI(p))
                    .ToList();
            }

            return vm;
        }

        public IList<EstanteriaVirtualViewModel> ConvertListENToViewModel(IList<EstanteriaEN> ens)
        {
            if (ens == null) return new List<EstanteriaVirtualViewModel>();

            var list = new List<EstanteriaVirtualViewModel>();
            foreach (var en in ens)
            {
                list.Add(ConvertENToModelUI(en));
            }
            return list;
        }
    }
}
