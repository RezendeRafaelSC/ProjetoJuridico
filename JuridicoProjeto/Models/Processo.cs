﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuridicoProjeto.Models
{
   
    public class Processo
    {
        protected Processo() 
        {
            Documentos = new List<Documento>();
        }
        public Processo( int numeroProcesso, string tema, double? valor)
        {
            NumeroProcesso = numeroProcesso;
            Tema = tema;
            Valor = valor;
            
        }

        public int Id { get; set; }        
        public int NumeroProcesso { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }    
        public string AdvogadoId { get; set; }
        public virtual Advogado Advogado { get; set; }

        public string Tema { get;set; }
        public double? Valor { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }

    }
}
