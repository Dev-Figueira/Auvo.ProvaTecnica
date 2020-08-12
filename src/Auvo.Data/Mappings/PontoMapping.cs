using Auvo.Busness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auvo.Data.Mappings
{
    public class PontoMapping : IEntityTypeConfiguration<Ponto>
    {
        public void Configure(EntityTypeBuilder<Ponto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnType("varchar(10)");

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(r => r.Registros)
                .WithOne(p => p.Ponto)
                .HasForeignKey(p => p.PontoId);

            builder.ToTable("Ponto");
        }
    }
}
