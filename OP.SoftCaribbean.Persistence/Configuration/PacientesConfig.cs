using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Persistence.Configuration
{
    public class PacientesConfig : IEntityTypeConfiguration<Pacientes>
    {
        public void Configure(EntityTypeBuilder<Pacientes> builder)
        {
            builder.HasKey(e => e.nmid);

            builder.Property(e => e.nmid);

            builder.Property(e => e.cdusuario)
                .HasMaxLength(150)
                .IsUnicode()
                .HasColumnType("varchar");

            builder.Property(e => e.dsarl)
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(e => e.dscondicion)
                .HasColumnType("text");

            builder.Property(e => e.dseps)
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(e => e.febaja)
                .HasColumnType("datetime");

            builder.Property(e => e.feregistro)
                .HasColumnType("datetime");

            builder.Property(e => e.nmidMedicotra).HasColumnType("int");

            builder.Property(e => e.nmidPersona).HasColumnType("int");

            builder.HasOne(d => d.nmidMedicotraNavigation)
                .WithMany(p => p.PacienteNmidMedicotraNavigations)
                .HasForeignKey(d => d.nmidMedicotra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK02_Pacientes_Personas");

            builder.HasOne(d => d.nmidPersonaNavigation)
                .WithMany(p => p.PacienteNmidPersonaNavigations)
                .HasForeignKey(d => d.nmidPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK01_Pacientes_Personas");
        }
    }
}
