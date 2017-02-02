using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuanny.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        #region Metodos

        //Lista com os produtos a serem comprados
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.Produtoid == produto.Produtoid);

            if(item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover
        public void RemoveItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(l => l.Produto.Produtoid == produto.Produtoid);
        }

        //Obter o valor total
        public decimal ObterValTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Limpar o carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        //Itens do carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }

        #endregion
    }

    //Construtor com os campos do carrinho de compras
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
