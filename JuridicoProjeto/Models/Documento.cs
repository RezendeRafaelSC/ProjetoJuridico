using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuridicoProjeto.Models
{
  
    public class Documento
    {
        public Documento(string nome, string caminho, string extensao, int processoId)
        {
            Nome = nome;
            Caminho = caminho;
            Extensao = extensao;
            ProcessoId = processoId;
        }
     
        public int Id { get; set; }
      
        public string Nome { get; set; }
       
        public string Caminho { get; set; }
      
        public string Extensao { get; set; }
       
        public int ProcessoId { get; set; }
        public virtual Processo Processo { get; set; } = null!;

    }
}
