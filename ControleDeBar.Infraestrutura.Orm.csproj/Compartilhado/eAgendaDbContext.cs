using Microsoft.EntityFrameworkCore;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eAgenda.Infraestrutura.Orm.Compartilhado
{
    public class eAgendaDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ItemTarefa> ItensTarefa { get; set; }

        public eAgendaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(eAgendaDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
