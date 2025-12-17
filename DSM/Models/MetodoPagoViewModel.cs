using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class MetodoPagoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El tipo de pago es obligatorio")]
        [Display(Name = "Tipo de Pago")]
        public TipoPagoEnum TipoPago { get; set; }

        public bool Valido { get; set; }
    }
}
