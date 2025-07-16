using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloCategoria
{
    public class RepositorioCategoriaOrm : IRepositorioCategoria
    {
        private readonly DbSet<Categoria> categorias;
        private readonly eAgendaDbContext contexto;

        public RepositorioCategoriaOrm(eAgendaDbContext contexto)
        {
            this.contexto = contexto;
            categorias = contexto.Set<Categoria>();
        }

        public void CadastrarRegistro(Categoria novoRegistro)
        {
            categorias.Add(novoRegistro);
        }

        public bool EditarRegistro(Guid idRegistro, Categoria registroEditado)
        {
            var categoriaExistente = SelecionarRegistroPorId(idRegistro);

            if (categoriaExistente == null)
                return false;

            categoriaExistente.AtualizarRegistro(registroEditado);
            categorias.Update(categoriaExistente);

            return true;
        }

        public bool ExcluirRegistro(Guid idRegistro)
        {
            var categoria = SelecionarRegistroPorId(idRegistro);

            if (categoria == null)
                return false;

            categorias.Remove(categoria);

            return true;
        }

        public List<Categoria> SelecionarRegistros()
        {
            return categorias
                .Include(c => c.Despesas)
                .ToList();
        }

        public Categoria? SelecionarRegistroPorId(Guid idRegistro)
        {
            return categorias
                .Include(c => c.Despesas)
                .FirstOrDefault(x => x.Id == idRegistro);
        }
    }
}