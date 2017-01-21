using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Zuanny.LojaVirtual.Web.HtmlHelpers;
using Zuanny.LojaVirtual.Web.Models;

namespace Zuanny.LojaVitual.UnitTest
{
    [TestClass]
    public class UnitTestZuany
    {
        [TestMethod]
        public void TestMethod1()
        {
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 1,
                ItensTotal = 5
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                +@"<a class=""btn btn-default btn-primary selected"" href="" Pagina2"">2</a>"
                +@"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );
        }
    }
}
