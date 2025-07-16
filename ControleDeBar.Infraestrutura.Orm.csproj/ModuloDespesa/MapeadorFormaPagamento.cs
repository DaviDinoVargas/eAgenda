using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infra.Orm.Mapeadores
{
    public class FormaPagamentoLookup
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class MapeadorFormaPagamento : IEntityTypeConfiguration<FormaPagamentoLookup>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoLookup> builder)
        {
            builder.Property("TBFormaPagamento");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new FormaPagamentoLookup { Id = 0, Nome = "Dinheiro" },
                new FormaPagamentoLookup { Id = 1, Nome = "Cartao" },
                new FormaPagamentoLookup { Id = 2, Nome = "Pix" }
            );
        }
    }
}
