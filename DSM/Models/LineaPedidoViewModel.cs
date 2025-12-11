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
        [Range(1, 100000, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }

        [Display(Prompt = "Precio de la línea", Description = "Precio de la línea de pedido", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser válido")]
        [Range(0.0, 1000000.0, ErrorMessage = "El precio debe estar entre 0 y 1.000.000")]
        public double Precio { get; set; }

        // Para enlazar con el pedido (FK)
        [ScaffoldColumn(false)]
        public int IdPedido { get; set; }
    }
}
