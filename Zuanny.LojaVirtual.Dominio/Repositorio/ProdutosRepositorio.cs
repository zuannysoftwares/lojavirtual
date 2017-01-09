using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuanny.LojaVirtual.Dominio.Entidade;

namespace Zuanny.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        //Referencia ao Entity pra fazer as qwerys
        private readonly EFDbContext _context = new EFDbContext();
        
        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }
    }
}
