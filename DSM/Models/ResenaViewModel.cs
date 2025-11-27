using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class ResenaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Descripcion de la reseña", Description = "Texto de la reseña", Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar una descripción para la reseña")]
        [StringLength(1000, ErrorMessage = "La descripción no puede tener más de 1000 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Nota (0-10)", Description = "Valoración numérica", Name = "Nota")]
        [Required(ErrorMessage = "Debe indicar una nota para la reseña")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        public int Nota { get; set; }

        [Display(Prompt = "Fecha de la reseña", Description = "Fecha", Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Usuario que realiza la reseña", Name = "Usuario")]
        public string UsuarioEmail { get; set; }

        [Display(Prompt = "Id del producto", Description = "Producto reseñado", Name = "ProductoId")]
        public int ProductoId { get; set; }
    }
}
