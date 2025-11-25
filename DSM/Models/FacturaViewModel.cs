using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class FacturaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Indica el número de factura", Description = "Número de factura", Name = "Número")]
        [Required(ErrorMessage = "Debe indicar un número de factura")]
        [StringLength(maximumLength: 200, ErrorMessage = "El número debe ser válido")]
        public string Numero { get; set; }

        [Display(Prompt = "Introduce el importe total del pedido", Description = "Importe total del pedido", Name = "Importe Total")]
        [Required(ErrorMessage = "Debe indicar un importe para la factura")]
        [DataType(DataType.Currency, ErrorMessage = "El importe debe ser válido")]
        [Range(minimum: 0, maximum: 100000, ErrorMessage = "El importe debe ser mayor a 0€ y menor a 100.000€")]
        public decimal ImporteTotal { get; set; }

        public DateTime? Fecha { get; internal set; }
    }
}
