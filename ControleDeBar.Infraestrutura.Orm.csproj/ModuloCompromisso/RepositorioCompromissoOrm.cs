using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso
{
    public class RepositorioCompromissoOrm : IRepositorioCompromisso
    {
        private readonly DbSet<Compromisso> compromissos;
        private readonly eAgendaDbContext contexto;

        public RepositorioCompromissoOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
            compromissos = contexto.Set<Compromisso>();
        }

        public void CadastrarRegistro(Compromisso novoRegistro)
        {
            compromissos.Add(novoRegistro);
        }

        public bool EditarRegistro(Guid idRegistro, Compromisso registroEditado)
        {
            var compromissoExistente = SelecionarRegistroPorId(idRegistro);

            if (compromissoExistente == null)
                return false;

            compromissoExistente.AtualizarRegistro(registroEditado);
            compromissos.Update(compromissoExistente);

            return true;
        }

        public bool ExcluirRegistro(Guid idRegistro)
        {
            var compromisso = SelecionarRegistroPorId(idRegistro);

            if (compromisso == null)
                return false;

            compromissos.Remove(compromisso);

            return true;
        }

        public List<Compromisso> SelecionarRegistros()
        {
            return compromissos
                .Include(c => c.Contato)
                .ToList();
        }

        public Compromisso? SelecionarRegistroPorId(Guid idRegistro)
        {
            return compromissos
                .Include(c => c.Contato)
                .FirstOrDefault(x => x.Id == idRegistro);
        }
    }
}
