using System;
using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class LoginUsuarioViewModel
    {
        [Display(Prompt = "Introduce el DNI del usuario", Description = "DNI usuario", Name = "DNIUsuario")]
        [Required(ErrorMessage = "El DNI del Usuario es obligatorio")]

        public string DNI { get; set; }

        [Display(Prompt = "Introduce el Password del usuario", Description = "Password usuario", Name = "Password")]
        [Required(ErrorMessage = "El password del Usuario es obligatorio")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }

    public class UsuarioViewModel
    {
        [Display(Prompt = "Introduce el email", Description = "Email del usuario", Name = "email")]
        [Required(ErrorMessage = "El email del Usuario es obligatorio")]

        public string email { get; set; }

        [Display(Prompt = "Introduce el Nombre del Usuario", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre del Usuario es obligatorio")]

        public string Nombre { get; set; }

        [Display(Prompt = "Introduce el Password del Usuario", Description = "Password del Usuario", Name = "Password")]
        [Required(ErrorMessage = "El password del Usuario es obligatorio")]
        [DataType(DataType.Password)]
        public string contraseña { get; set; }


        [Display(Prompt = "Introduce el Fecha de nacimiento del Usuario", Description = "Fecha de nacimiento", Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Prompt = "Introduce el Código postal", Description = "Código Postal", Name = "Código Postal")]
        [DataType(DataType.Currency)]
        public int CodPostal { get; set; }

        [Display(Prompt = "Introduce la dirección", Description = "Dirección", Name = "Dirección")]

        public string Direccion { get; set; }

        
    }
}
