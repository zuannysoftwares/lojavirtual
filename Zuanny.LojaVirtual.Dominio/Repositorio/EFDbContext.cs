using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuanny.LojaVirtual.Dominio.Entidade;

namespace Zuanny.LojaVirtual.Dominio.Repositorio
{
    public class EFDbContext : DbContext
    {
        //Aqui faço o mapeamento das tabelas do meu banco
        public DbSet<Produto> Produtos { get; set; }

        //Impede de colocar o nome das tabelas no plural automaticamente
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
        }
    }
}
