using PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class MetodoPagoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public TipoPagoEnum TipoPago { get; internal set; }

        public bool Valido { get; set; }
    }
}
