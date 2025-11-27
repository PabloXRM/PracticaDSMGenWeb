using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class LineaPedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Num { get; set; }

        [Display(Prompt = "Id del pedido", Description = "Identificador del pedido", Name = "Pedido")]
        [Required(ErrorMessage = "Debe indicar el id del pedido")]
        public int PedidoId { get; set; }

        [Display(Prompt = "Id del producto", Description = "Identificador del producto", Name = "Producto")]
        [Required(ErrorMessage = "Debe indicar el id del producto")]
        public int ProductoId { get; set; }

        [Display(Prompt = "Cantidad", Description = "Cantidad pedida", Name = "Cantidad")]
        [Required(ErrorMessage = "Debe indicar una cantidad")]
        [Range(1, 100000, ErrorMessage = "La cantidad debe ser un entero positivo")]
        public int Cantidad { get; set; }

        [Display(Prompt = "Precio unitario", Description = "Precio unitario de la línea", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser válido")]
        [Range(0.0, 1000000.0, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        public decimal Precio { get; set; }
    }
}