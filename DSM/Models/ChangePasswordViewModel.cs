using System.ComponentModel.DataAnnotations;

namespace DSM.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Introduce tu contraseña actual")]
        [DataType(DataType.Password)]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "Introduce la nueva contraseña")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        public string PasswordNueva { get; set; }

        [Required(ErrorMessage = "Confirma la nueva contraseña")]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNueva), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPasswordNueva { get; set; }
    }
}
