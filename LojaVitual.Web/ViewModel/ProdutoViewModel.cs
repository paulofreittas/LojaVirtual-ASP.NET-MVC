using LojaVirtual.Dominio.Entidades;
using LojaVitual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVitual.Web.ViewModel
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }
    }
}