using JuridicoProjeto.Mappings;
using Microsoft.EntityFrameworkCore;
using JuridicoProjeto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuridicoProjeto.Data
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Advogado> Advogado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Processo> Processo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new ProcessoMap());
            modelBuilder.ApplyConfiguration(new AdvogadoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
