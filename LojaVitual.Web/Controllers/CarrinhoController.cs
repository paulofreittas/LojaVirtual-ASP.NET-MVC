using System;
using System.Linq;
using System.Web.Mvc;
using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Repositorio.Repositories;
using LojaVitual.Web.ViewModel;

namespace LojaVitual.Web.Controllers
{

    public class CarrinhoController : Controller
    {
        private ProdutoRepository _produtoRepository;


        public RedirectToRouteResult Adicionar(int Id, string returnUrl)
        {
            _produtoRepository = new ProdutoRepository();

            Produto produto = _produtoRepository.Produtos.FirstOrDefault(p => p.Id == Id);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho) Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int Id, string returnUrl)
        {
            _produtoRepository = new ProdutoRepository();

            Produto produto = _produtoRepository.Produtos.FirstOrDefault(p => p.Id == Id);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel()
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            return View(new Pedido());
        }
    }
}