using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class MapeadorDespesa : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
           
            builder.Property(d => d.Id)
                .IsRequired();

            builder.Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Valor)
                .IsRequired();

            builder.Property(d => d.DataOcorencia) 
                .IsRequired();

            builder.Property(d => d.FormaPagamento)
                .HasConversion<int>()
                .IsRequired();

            builder.HasMany(d => d.Categorias)
                .WithMany(c => c.Despesas)
                .UsingEntity(j => j.HasKey("DespesaId", "CategoriaId"));
        }
    }
}