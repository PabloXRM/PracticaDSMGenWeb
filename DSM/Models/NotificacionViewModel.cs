using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System;
using System.ComponentModel.DataAnnotations;
using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;

namespace DSM.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Tipo de notificación", Description = "Tipo de notificación", Name = "Tipo")]
        [Required(ErrorMessage = "Debe indicar un tipo de notificación")]
        public TipoNotificacionEnum Tipo { get; set; }

        public DateTime? Fecha { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Fotos { get; set; }

        // Usuario que recibe la notificaci�n (por simplicidad, el email)
        [ScaffoldColumn(false)]
        public string EmailUsuario { get; set; }
    }
}
