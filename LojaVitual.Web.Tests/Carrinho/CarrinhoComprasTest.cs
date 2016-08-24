using LojaVirtual.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVitual.Web.Tests.CarrinhoCompras
{
    [TestClass]
    public class CarrinhoComprasTest
    {

        Produto produto1 = new Produto
        {
            Id = 1,
            Nome = "Teste 1",
            Preco = 358
        };

        Produto produto2 = new Produto
        {
            Id = 2,
            Nome = "Teste 2",
            Preco = 415
        };

        Carrinho carrinho = new Carrinho();

        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {


            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void SomaDosValoresDosProdutos()
        {

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 1);

            Assert.AreEqual(carrinho.ObterValorTotal(), 1131);

        }

        [TestMethod]
        public void RemoverItemDoCarrinho()
        {

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.RemoverItem(produto1);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 1);

        }

        [TestMethod]
        public void LimparCarrinho()
        {

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.LimparCarrinho();

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 0);

        }
    }
}
