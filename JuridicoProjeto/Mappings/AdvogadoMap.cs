using JuridicoProjeto.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JuridicoProjeto.Mappings
{
    public class AdvogadoMap : IEntityTypeConfiguration<Advogado>
    {
        public void Configure(EntityTypeBuilder<Advogado> builder)
        {
            builder.ToTable("Advogados");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.oab).HasColumnType("varchar(14)");


        }
    }
}
