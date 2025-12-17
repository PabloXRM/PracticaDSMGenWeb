using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;

namespace DSM.Models
{
    public class HomeIndexViewModel
    {
        public string? Q { get; set; }
        public EstiloEnum? Estilo { get; set; }
        public FormatoEnum? Formato { get; set; }

        public IList<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();

        public ProductoViewModel? ProductoRecomendado { get; set; }

        public List<ProductoViewModel> ProductosRecomendados { get; set; } = new List<ProductoViewModel>();
    }
}
