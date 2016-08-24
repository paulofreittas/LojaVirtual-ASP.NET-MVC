using LojaVirtual.Repositorio.Repositories;
using LojaVitual.Web.Models;
using LojaVitual.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVitual.Web.Controllers
{
    public class VitrineController : Controller
    {

        private ProdutoRepository _produtoRepository;
        public int ProdutosPorPagina = 2;

        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _produtoRepository = new ProdutoRepository();
            ProdutoViewModel model = new ProdutoViewModel
            {

                Produtos = _produtoRepository.Produtos.ToList().OrderBy(p => p.Nome)
                .Where(p => categoria == null || p.Categoria == categoria)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _produtoRepository.Produtos.Count()
                },

                CategoriaAtual = categoria
            };
           

            return View(model);
        }
    }
}