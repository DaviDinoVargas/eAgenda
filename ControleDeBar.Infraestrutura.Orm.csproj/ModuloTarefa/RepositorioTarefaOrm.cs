using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class RepositorioTarefaOrm : IRepositorioTarefa
    {
        private readonly DbSet<Tarefa> tarefas;
        private readonly DbSet<ItemTarefa> itensTarefa;
        private readonly eAgendaDbContext contexto;

        public RepositorioTarefaOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
            tarefas = contexto.Set<Tarefa>();
            itensTarefa = contexto.Set<ItemTarefa>();
        }

        public void CadastrarRegistro(Tarefa novaTarefa)
        {
            tarefas.Add(novaTarefa);
        }

        public bool EditarRegistro(Guid idTarefa, Tarefa tarefaEditada)
        {
            var tarefaExistente = SelecionarRegistroPorId(idTarefa);

            if (tarefaExistente == null)
                return false;

            tarefaExistente.AtualizarRegistro(tarefaEditada);
            tarefas.Update(tarefaExistente);

            return true;
        }

        public bool ExcluirRegistro(Guid idTarefa)
        {
            var tarefa = SelecionarRegistroPorId(idTarefa);

            if (tarefa == null)
                return false;

            tarefas.Remove(tarefa);

            return true;
        }

        public List<Tarefa> SelecionarRegistros()
        {
            return tarefas
                .Include(t => t.Itens)
                .ToList();
        }

        public Tarefa? SelecionarRegistroPorId(Guid idTarefa)
        {
            return tarefas
                .Include(t => t.Itens)
                .FirstOrDefault(t => t.Id == idTarefa);
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {
            return tarefas
                .Include(t => t.Itens)
                .Where(t => !t.Concluida)
                .ToList();
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            return tarefas
                .Include(t => t.Itens)
                .Where(t => t.Concluida)
                .ToList();
        }

        public void AdicionarItem(ItemTarefa item)
        {
            itensTarefa.Add(item);
        }

        public bool AtualizarItem(ItemTarefa itemAtualizado)
        {
            var itemExistente = itensTarefa.FirstOrDefault(i => i.Id == itemAtualizado.Id);

            if (itemExistente == null)
                return false;

            itemExistente.Titulo = itemAtualizado.Titulo;
            itemExistente.Concluido = itemAtualizado.Concluido;

            itensTarefa.Update(itemExistente);

            return true;
        }

        public bool RemoverItem(ItemTarefa item)
        {
            var itemExistente = itensTarefa.FirstOrDefault(i => i.Id == item.Id);

            if (itemExistente == null)
                return false;

            itensTarefa.Remove(itemExistente);
            return true;
        }
    }
}
