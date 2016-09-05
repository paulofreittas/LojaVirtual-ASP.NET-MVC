using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorio.Repositories
{
    public class ProdutoRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        public IEnumerable<Produto> GetProdutosForPage(int pagina, int ProdutosPorPagina, string categoria)
        { 
            return _context.Produtos.OrderBy(p => p.Id)
                         .Where(p => categoria == null || p.Categoria == categoria)
                         .Skip((pagina - 1) * ProdutosPorPagina)
                         .Take(ProdutosPorPagina)
                         .ToList();
        }

        public IEnumerable<Produto> GetPagesForCategory(int pagina, int ProdutosPorPagina, string categoria)
        {
            return _context.Produtos.OrderBy(p => p.Id)
                         .Where(p => categoria == null || p.Categoria == categoria)
                         .ToList();
        }
    }
}
