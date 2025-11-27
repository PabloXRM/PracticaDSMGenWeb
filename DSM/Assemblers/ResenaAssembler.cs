using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Assemblers
{
    public class ResenaAssembler
    {
        public ResenaViewModel ConvertENToModelUI(ReseñaEN en)
        {
            if (en == null) return null;

            return new ResenaViewModel
            {
                Id = en.Id,
                Descripcion = en.Descripcion,
                Nota = en.Nota,
                Fecha = en.Fecha.GetValueOrDefault(),
                UsuarioEmail = en.Usuario != null ? en.Usuario.Email : null,
                ProductoId = en.Producto != null ? en.Producto.Id : 0
            };
        }

        public IList<ResenaViewModel> ConvertListENToViewModel(IList<ReseñaEN> ens)
        {
            IList<ResenaViewModel> list = new List<ResenaViewModel>();
            if (ens == null) return list;
            foreach (var en in ens)
            {
                list.Add(ConvertENToModelUI(en));
            }
            return list;
        }
    }
}
