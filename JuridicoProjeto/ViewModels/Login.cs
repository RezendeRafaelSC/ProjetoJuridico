using System.ComponentModel.DataAnnotations;

namespace JuridicoProjeto.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage= "Por favor, informe o seu email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua senha.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display (Name ="Lembrar minhas credenciais")]
        public bool RememberMe { get; set; }
    }
}
