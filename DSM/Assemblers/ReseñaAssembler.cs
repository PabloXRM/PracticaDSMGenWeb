// ReseñaAssembler.cs
using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class ReseñaAssembler
    {
        public ReseñaViewModel ConvertENToModelUI(ReseñaEN en)
        {
            ReseñaViewModel res = new ReseñaViewModel();

            res.Id = en.Id;
            res.Descripcion = en.Descripcion;
            res.Nota = en.Nota;
            res.Fecha = en.Fecha;
            res.IdProducto = en.Producto.Id;
            res.NombreProducto = en.Producto.Descripcion;

            return res;
        }

        public IList<ReseñaViewModel> ConvertListENToViewModel(IList<ReseñaEN> ens)
        {
            IList<ReseñaViewModel> resList = new List<ReseñaViewModel>();
            foreach (ReseñaEN en in ens)
            {
                resList.Add(ConvertENToModelUI(en));
            }
            return resList;
        }
    }
}
