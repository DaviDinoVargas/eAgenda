using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class PrioridadeTarefaLookup
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class MapeadorPrioridadeTarefa : IEntityTypeConfiguration<PrioridadeTarefaLookup>
    {
        public void Configure(EntityTypeBuilder<PrioridadeTarefaLookup> builder)
        {
            builder.ToTable("TBPrioridadeTarefa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new PrioridadeTarefaLookup { Id = 0, Nome = "Baixa" },
                new PrioridadeTarefaLookup { Id = 1, Nome = "Normal" },
                new PrioridadeTarefaLookup { Id = 2, Nome = "Alta" }
            );
        }
    }
}
