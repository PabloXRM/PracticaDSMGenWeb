using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public TipoNotificacionEnum Tipo { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Título")]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Display(Name = "Fotos")]
        public string Fotos { get; set; }
    }
}
