using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class EditPerfilViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio")]
        [Range(0, 99999, ErrorMessage = "Código postal no válido")]
        public int CodPostal { get; set; }


    }
}
