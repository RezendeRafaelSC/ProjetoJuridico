using JuridicoProjeto.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuridicoProjeto.Models
{
    public class Usuario : IdentityUser
    {
           
        public string Name { get; set; }
        public string Cpf { get; set; }

    }
}


