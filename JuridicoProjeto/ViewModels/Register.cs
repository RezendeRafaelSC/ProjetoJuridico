using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JuridicoProjeto.ViewModels
{
    public class Register : IValidatableObject
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não são iguais!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? Cpf { get; set; }

        public bool isAdvogado { get; set; }

        public string? Oab { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (isAdvogado && string.IsNullOrWhiteSpace(Oab))
            {
                validationResults.Add(new ValidationResult(
                    "O campo OAB é obrigatório quando 'É advogado?' está marcado.",
                    new[] { nameof(Oab) }
                ));
            }

            return validationResults;
        }
    }
}
