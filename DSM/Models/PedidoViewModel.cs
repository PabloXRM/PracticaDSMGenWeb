using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DSM.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Carrito de compras", Description = "Carrito asociado al pedido", Name = "Carrito")]
        [Required(ErrorMessage = "Debe asociar un carrito al pedido")]
        public Carrito? Carrito { get; set; }

        [Display(Prompt = "Número de pedido", Description = "Número único del pedido", Name = "Número de Pedido")]
        [Required(ErrorMessage = "Debe ingresar un número de pedido")]
        [StringLength(50, ErrorMessage = "El número de pedido no puede exceder 50 caracteres")]
        public string Numero { get; set; }

        [Display(Prompt = "Fecha del pedido", Description = "Fecha en que se realizó el pedido", Name = "Fecha")]
        [Required(ErrorMessage = "Debe ingresar la fecha del pedido")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Precio total", Description = "Precio total del pedido", Name = "Precio Total")]
        [Required(ErrorMessage = "Debe ingresar el precio total")]
        // Usar sobrecarga numérica para evitar conversiones dependientes de cultura
        [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor a 0 y menor a 1,000,000")]
        [RegularExpression(@"^\d+([.,]\d{1,2})?$", ErrorMessage = "Formato de precio inválido")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalPrecio { get; set; }

        [Display(Prompt = "Estado del pedido", Description = "Estado actual del pedido", Name = "Estado")]
        [Required(ErrorMessage = "Debe seleccionar un estado")]
        public EstadoPedido? EstadoPedido { get; set; }

        // Nueva colección para mostrar las líneas del pedido
        public IList<LineaPedidoViewModel> Lineas { get; set; } = new List<LineaPedidoViewModel>();
    }

    public enum EstadoPedido
    {
        Pendiente,
        Confirmado,
        Enviado,
        Entregado,
        Cancelado
    }

    public enum Carrito
    {
        Vacio,
        ConArticulos
    }
}