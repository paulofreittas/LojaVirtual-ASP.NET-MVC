using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaVirtual.Dominio.Entidades;

namespace LojaVitual.Web.ViewModel
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; }
    }
}