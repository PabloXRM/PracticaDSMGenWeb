// ReseñaViewModel.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class ReseñaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe tu reseña", Description = "Texto de la reseña", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripción para la reseña")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Introduce la nota", Description = "Nota de la reseña", Name = "Nota")]
        [Required(ErrorMessage = "Debe indicar una nota para la reseña")]
        [Range(minimum: 0, maximum: 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        public int Nota { get; set; }

        [Display(Prompt = "Introduce la fecha de la reseña", Description = "Fecha de la reseña", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar una fecha para la reseña")]
        [DataType(DataType.Date, ErrorMessage = "La fecha no es válida")]
        public DateTime? Fecha { get; set; }

        // Campos opcionales para enlazar con Producto (por si luego quieres mostrarlo)
        [ScaffoldColumn(false)]
        public int IdProducto { get; set; }

        [Display(Prompt = "Producto reseñado", Description = "Producto reseñado", Name = "Producto")]
        public string NombreProducto { get; set; }
    }
}
