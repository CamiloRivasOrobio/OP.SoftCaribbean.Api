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
    public class DataMaestraConfig : IEntityTypeConfiguration<DataMaestra>
    {
        public void Configure(EntityTypeBuilder<DataMaestra> builder)
        {
            builder.ToTable("DataMaestra");

            builder.HasKey(p => p.nmdato);

            builder.Property(e => e.nmdato)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.Property(e => e.cddato)
                .HasMaxLength(20)
                .IsUnicode()
                .HasColumnType("varchar");

            builder.Property(e => e.cddato1)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.cddato2)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.cddato3)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.dsddato)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder.Property(e => e.febaja)
                .HasColumnType("datetime");

            builder.Property(e => e.feregistro)
                .HasColumnType("datetime");

            builder.Property(e => e.nmmaestro)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.HasOne(d => d.nmmaestroNavigation)
                .WithMany(p => p.DataMaestra)
                .HasForeignKey(d => d.nmmaestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK01_DataMaestra_Maestras");
        }
    }
}
