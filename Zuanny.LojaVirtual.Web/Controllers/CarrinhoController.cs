using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zuanny.LojaVirtual.Dominio.Entidade;
using Zuanny.LojaVirtual.Dominio.Repositorio;

namespace Zuanny.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;
        
        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.Produtoid == produtoId);
 
            if(produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
           
        }

        private Carrinho ObterCarrinho()
        {
            //Crio uma Session de Carrinho
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if(carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

       public RedirectToRouteResult Remover(int produtoid, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.Produtoid == produtoid);

           if(produto != null)
           {
               ObterCarrinho().RemoveItem(produto);
           }

           return RedirectToAction("Index", new { returnUrl });
        }
    }
}