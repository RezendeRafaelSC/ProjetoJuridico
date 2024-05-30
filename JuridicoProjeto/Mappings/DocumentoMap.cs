using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuridicoProjeto.Models;

namespace JuridicoProjeto.Mappings
{
    public class DocumentoMap : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("Documentos");

            builder.Property(p => p.Id)
              .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Caminho)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Extensao)
              .HasColumnType("varchar(100)")
              .IsRequired();
        }
    }
}
