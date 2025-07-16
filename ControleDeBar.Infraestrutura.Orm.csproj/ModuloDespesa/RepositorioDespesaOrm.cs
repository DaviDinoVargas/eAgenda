using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class RepositorioDespesaOrm : IRepositorioDespesa
    {
        private readonly DbSet<Despesa> despesas;
        private readonly eAgendaDbContext contexto;

        public RepositorioDespesaOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
            despesas = contexto.Set<Despesa>();
        }

        public void CadastrarRegistro(Despesa novoRegistro)
        {
            despesas.Add(novoRegistro);
        }

        public bool EditarRegistro(Guid idRegistro, Despesa registroEditado)
        {
            var despesaExistente = SelecionarRegistroPorId(idRegistro);

            if (despesaExistente == null)
                return false;

            despesaExistente.AtualizarRegistro(registroEditado);
            despesas.Update(despesaExistente);

            return true;
        }

        public bool ExcluirRegistro(Guid idRegistro)
        {
            var despesa = SelecionarRegistroPorId(idRegistro);

            if (despesa == null)
                return false;

            despesas.Remove(despesa);

            return true;
        }

        public List<Despesa> SelecionarRegistros()
        {
            return despesas
                .Include(d => d.Categorias)
                .ToList();
        }

        public Despesa? SelecionarRegistroPorId(Guid idRegistro)
        {
            return despesas
                .Include(d => d.Categorias)
                .FirstOrDefault(x => x.Id == idRegistro);
        }
    }
}