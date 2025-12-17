using System.Collections.Generic;

namespace DSM.Models
{
    public class EstanteriaVirtualViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();
        public string Valoracion { get; set; }
        public int Visitas { get; set; }
        public bool Visible { get; set; }
    }
}
