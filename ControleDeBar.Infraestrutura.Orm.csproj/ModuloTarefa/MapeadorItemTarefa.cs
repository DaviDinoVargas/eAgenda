using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorItemTarefa : IEntityTypeConfiguration<ItemTarefa>
    {
        public void Configure(EntityTypeBuilder<ItemTarefa> builder)
        {
            builder.Property(i => i.Id)
                .IsRequired();

            builder.Property(i => i.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.Concluido)
                .IsRequired();

            builder.HasOne(i => i.Tarefa)
                .WithMany(t => t.Itens)
                .HasForeignKey("Tarefa_Id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
