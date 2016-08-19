using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using LojaVitual.Web.Models;
using LojaVitual.Web.HtmlHelpers;

namespace LojaVitual.Web.Tests.PaginacaoTest
{
    [TestClass]
    public class PaginacaoTest
    {
        [TestMethod]
        public void TestePaginacao()
        {

            //Arrange

            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 2,
                ItensTotal = 3
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert

            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
              + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>", resultado.ToString()
                );
        }
    }
}
