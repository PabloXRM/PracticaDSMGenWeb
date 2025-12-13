using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class LineaPedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Num { get; set; }

        [Display(Prompt = "Cantidad de unidades", Description = "Cantidad del producto en la línea", Name = "Cantidad")]
        [Required(ErrorMessage = "Debe indicar una cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe indicar un precio")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser válido")]
        public double Precio { get; set; }

        [ScaffoldColumn(false)]
        public int IdPedido { get; set; }
    }
}