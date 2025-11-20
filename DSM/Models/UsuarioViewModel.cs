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
}
