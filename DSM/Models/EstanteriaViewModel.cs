using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DSM.Models
{
    public class EstanteriaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Describe la estantería", Description = "Descripción de la estantería", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar un nombre para la estantería")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }
        
        public string Valoracion { get; set; }
        
        public int Visitas { get; set; }
        
        public bool Visible { get; set; }

        public List<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();
    }
}
