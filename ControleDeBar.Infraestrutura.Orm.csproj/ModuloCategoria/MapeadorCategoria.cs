using eAgenda.Dominio.ModuloCategoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloCategoria
{
    public class MapeadorCategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(c => c.Despesas)
                .WithMany(d => d.Categorias)
                .UsingEntity(j => j
                    .HasKey("Categoria_Id", "Despesa_Id"));
        }
    }
}