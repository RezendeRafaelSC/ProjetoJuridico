using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuridicoProjeto.Models;
using static JuridicoProjeto.Models.Usuario;

namespace JuridicoProjeto.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


                builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

                builder.Property(p => p.Cpf)
               .HasColumnType("varchar(14)")
                .IsRequired();
        }
    }
}
