using eAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class MapeadorCompromisso : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Assunto)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Data)
                .IsRequired();

            builder.Property(c => c.HoraInicio)
                .IsRequired();

            builder.Property(c => c.HoraTermino)
                .IsRequired();

            builder.Property(c => c.Tipo)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(c => c.Local)
                .HasMaxLength(100);

            builder.Property(c => c.Link)
                .HasMaxLength(200);

            builder.HasOne(c => c.Contato)
                .WithMany(c => c.Compromissos)
                .HasForeignKey("Contato_Id")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
