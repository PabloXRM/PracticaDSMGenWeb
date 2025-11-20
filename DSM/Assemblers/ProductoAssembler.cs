using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSM.Assemblers
{
    public class ProductoAssembler
    {
        public ProductoViewModel ConvertENToModelUI(ProductoEN en)
        {
            ProductoViewModel art = new ProductoViewModel();
            art.Id = en.Id;
            art.Descripcion = en.Descripcion;
            art.Precio = (double)en.Precio;
            art.Stock = en.Stock;
            art.Formato = en.Formato;
            art.Estilo = en.Estilo;
            art.Fotos = en.Fotos;
            art.Artista = en.Artista;
            return art;
        }
   

        public IList<ProductoViewModel> ConvertListENToViewModel(IList<ProductoEN> ens)
        {
            IList<ProductoViewModel> arts = new List<ProductoViewModel>();
            foreach (ProductoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}
