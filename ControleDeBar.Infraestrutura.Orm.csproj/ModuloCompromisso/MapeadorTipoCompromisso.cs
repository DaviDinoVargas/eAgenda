using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class TipoCompromissoLookup
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class MapeadorTipoCompromisso : IEntityTypeConfiguration<TipoCompromissoLookup>
    {
        public void Configure(EntityTypeBuilder<TipoCompromissoLookup> builder)
        {
            builder.ToTable("TBTipoCompromisso");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new TipoCompromissoLookup { Id = 0, Nome = "Remoto" },
                new TipoCompromissoLookup { Id = 1, Nome = "Presencial" }
            );
        }
    }
}
