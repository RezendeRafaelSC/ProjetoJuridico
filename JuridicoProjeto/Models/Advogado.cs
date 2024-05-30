namespace JuridicoProjeto.Models
{
    public class Advogado
    {
        public string Id { get; set; }
        public string? oab {  get; set; }    
        public string? UserId { get; set; } 
        public virtual Usuario Usuario { get; set; }    
    }
}
