using Auvo.Busness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auvo.Data.Mappings
{
    class RegistroMapping : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Horario)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.NomeDoColaborador)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.TipoDoRegistro)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.ToTable("Registro");
        }
    }
}
