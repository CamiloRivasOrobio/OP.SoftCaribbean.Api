using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.SoftCaribbean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Persistence.Configuration
{
    public class MaestrasConfig : IEntityTypeConfiguration<Maestras>
    {
        public void Configure(EntityTypeBuilder<Maestras> builder)
        {
            builder.ToTable("Maestras");

            builder.HasKey(p => p.nmmaestro);

            builder.Property(p => p.nmmaestro)
               .HasMaxLength(150)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(p => p.cdmaestro)
                .HasMaxLength(5)
                .HasColumnType("varchar")
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.dsmaestro)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(p => p.feregistro)
               .HasColumnType("datetime");

            builder.Property(p => p.febaja)
               .HasColumnType("datetime");
        }
    }
}
