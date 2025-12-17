using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Assemblers
{
    public class EstanteriaAssembler
    {
        public EstanteriaViewModel ConvertENToModelUI(EstanteriaEN en)
        {
            EstanteriaViewModel est = new EstanteriaViewModel();
            est.Id = en.Id;
            est.Descripcion = en.Descripcion;
            est.Valoracion = en.Valoracion;
            est.Visitas = en.Visitas;
            est.Visible = en.Visible;

            // Mapear productos si existen
            if (en.Producto != null && en.Producto.Count > 0)
            {
                var productoAssembler = new ProductoAssembler();
                est.Productos = en.Producto
                    .Select(p => productoAssembler.ConvertENToModelUI(p))
                    .ToList();
            }

            return est;
        }


        public IList<EstanteriaViewModel> ConvertListENToViewModel(IList<EstanteriaEN> ens)
        {
            IList<EstanteriaViewModel> ests = new List<EstanteriaViewModel>();
            foreach (EstanteriaEN en in ens)
            {
                ests.Add(ConvertENToModelUI(en));
            }
            return ests;
        }
    }
}
