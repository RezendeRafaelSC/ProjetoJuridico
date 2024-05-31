using System.ComponentModel.DataAnnotations;

namespace JuridicoProjeto.ViewModels
{
    public class Update 
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }
      
        public string Oab { get; set; }

        [DataType(DataType.Password)]
        
        public string Password { get; set; }

    }
}
