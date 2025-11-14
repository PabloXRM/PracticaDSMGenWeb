using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DSM.Models
{
    public class ProductoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt ="Describe el producto", Description = "Descripción del producto", Name ="Descripción")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength:200, ErrorMessage ="La descripción no puede tener más de 200 caracteres")]
        public string Descripcion {  get; set; }

        [Display(Prompt = "Introduce el precio del producto", Description = "Precio del producto", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para el producto")]
        [DataType(DataType.Currency, ErrorMessage ="El precio debe ser válido")]
        [Range(minimum:0, maximum: 100000, ErrorMessage ="El precio debe ser mayor a 0€ y menor a 100.000€")]
        public double Precio { get; set; }

        [Display(Prompt = "Introduce el stock del producto", Description = "Stock del producto", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar un stock para el producto")]
        [RegularExpression("([0-9]+)", ErrorMessage ="Por favor introduce un numero entero para el stock del producto")]
        [Range(minimum: 0, maximum: 100000, ErrorMessage = "El stock debe ser mayor a 0 y menor a 100000")]
        public int Stock { get; set; }
    }
}
