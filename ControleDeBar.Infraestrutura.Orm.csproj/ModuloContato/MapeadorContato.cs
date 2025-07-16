using eAgenda.Dominio.ModuloContato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class MapeadorContato : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Empresa)
                .HasMaxLength(100);

            builder.Property(c => c.Cargo)
                .HasMaxLength(100);
        }
    }
}
