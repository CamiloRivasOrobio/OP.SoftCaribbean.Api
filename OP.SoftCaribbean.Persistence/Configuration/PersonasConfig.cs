using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Persistence.Configuration
{
    public class PersonasConfig : IEntityTypeConfiguration<Personas>
    {
        public void Configure(EntityTypeBuilder<Personas> builder)
        {
            builder.HasKey(e => e.nmid);

            builder.Property(e => e.nmid).HasColumnType("int").ValueGeneratedNever();

            builder.Property(e => e.cddocumento)
                .HasMaxLength(20)
                .IsUnicode()
                .HasColumnType("varchar");

            builder.Property(e => e.cdgenero)
                .HasMaxLength(10)
                .HasColumnType("varchar");

            builder.Property(e => e.cdtelefonoFijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cdtelefono_fijo")
                .HasColumnType("varchar");

            builder.Property(e => e.cdtelefonoMovil)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cdtelefono_movil")
                .HasColumnType("varchar");

            builder.Property(e => e.cdtipo)
                .HasMaxLength(10)
                .HasColumnType("varchar");

            builder.Property(e => e.cdusuario)
                .HasMaxLength(150)
                .HasColumnType("varchar");

            builder.Property(e => e.dsapellidos)
                .HasMaxLength(60)
                .HasColumnType("varchar");

            builder.Property(e => e.dsdireccion)
                .HasMaxLength(200)
                .HasColumnType("varchar");

            builder.Property(e => e.dsemail)
                .HasMaxLength(200)
                .HasColumnType("varchar");

            builder.Property(e => e.dsnombres)
                .HasMaxLength(60)
                .HasColumnType("varchar");

            builder.Property(e => e.dsphoto)
                .HasMaxLength(500)
                .HasColumnType("varchar");

            builder.Property(e => e.febaja).HasColumnType("datetime");

            builder.Property(e => e.fenacimiento)
                .HasColumnType("date");

            builder.Property(e => e.feregistro).HasColumnType("datetime");
        }
    }
}
