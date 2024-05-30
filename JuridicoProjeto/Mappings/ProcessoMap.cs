using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuridicoProjeto.Models;

namespace JuridicoProjeto.Mappings
{
    public class ProcessoMap : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.ToTable("Processos");

            builder.Property(p => p.Id)
              .ValueGeneratedOnAdd();

            builder.Property(p => p.NumeroProcesso)
                .HasColumnType("int");


            builder.Property(p => p.Tema)
                .HasColumnType("varchar(40)");


            builder.Property(p => p.Valor)
                .HasColumnType("numeric(30,2)");

            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Advogado).WithMany().HasForeignKey(x => x.AdvogadoId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
