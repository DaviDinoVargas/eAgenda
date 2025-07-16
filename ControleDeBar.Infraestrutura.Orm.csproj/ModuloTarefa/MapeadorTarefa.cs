using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorTarefa : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .IsRequired();

            builder.Property(t => t.DataConclusao);

            builder.Property(t => t.Concluida)
                .IsRequired();

            builder.HasMany(t => t.Itens)
                .WithOne(i => i.Tarefa)
                .HasForeignKey("Tarefa_Id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
