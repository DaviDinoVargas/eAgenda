using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloContato
{
    public class RepositorioContatoOrm : IRepositorioContato
    {
        private readonly DbSet<Contato> contatos;
        private readonly eAgendaDbContext contexto;

        public RepositorioContatoOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
            contatos = contexto.Set<Contato>();
        }

        public void CadastrarRegistro(Contato novoRegistro)
        {
            contatos.Add(novoRegistro);
        }

        public bool EditarRegistro(Guid idRegistro, Contato registroEditado)
        {
            var contatoExistente = SelecionarRegistroPorId(idRegistro);

            if (contatoExistente == null)
                return false;

            contatoExistente.AtualizarRegistro(registroEditado);
            contatos.Update(contatoExistente);

            return true;
        }

        public bool ExcluirRegistro(Guid idRegistro)
        {
            var contato = SelecionarRegistroPorId(idRegistro);

            if (contato == null)
                return false;

            contatos.Remove(contato);

            return true;
        }

        public List<Contato> SelecionarRegistros()
        {
            return contatos
                .Include(c => c.Compromissos)
                .ToList();
        }

        public Contato? SelecionarRegistroPorId(Guid idRegistro)
        {
            return contatos
                .Include(c => c.Compromissos)
                .FirstOrDefault(x => x.Id == idRegistro);
        }
    }
}
