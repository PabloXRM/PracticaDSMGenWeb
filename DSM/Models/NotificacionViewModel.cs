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

        [Display(Prompt = "Introduce la fecha de la notificación", Description = "Fecha de la notificación", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar una fecha para la notificación")]
        [DataType(DataType.Date, ErrorMessage = "La fecha no es válida")]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Introduce el título", Description = "Título de la notificación", Name = "Título")]
        [Required(ErrorMessage = "Debe indicar un título para la notificación")]
        [StringLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres")]
        public string Titulo { get; set; }

        [Display(Prompt = "Escribe la descripción", Description = "Descripción de la notificación", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripción")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Ruta de la imagen (opcional)", Description = "Fotos asociadas", Name = "Fotos")]
        public string Fotos { get; set; }

        // Usuario que recibe la notificación (por simplicidad, el email)
        [ScaffoldColumn(false)]
        public string EmailUsuario { get; set; }
    }
}
