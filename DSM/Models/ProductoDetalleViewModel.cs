using System.Collections.Generic;

namespace DSM.Models
{
    public class ProductoDetalleViewModel
    {
        public ProductoViewModel Producto { get; set; }
        public List<ResenaViewModel> Resenas { get; set; } = new List<ResenaViewModel>();

        // Para la UI
        public bool UsuarioLogueado { get; set; }
        public bool EsAdmin { get; set; }
        public bool PuedeResenar { get; set; }  // opcionl
    }
}
