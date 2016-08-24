using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itensCarrinhos = new List<ItemCarrinho>();

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itensCarrinhos; }
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = _itensCarrinhos.FirstOrDefault(p => p.Produto.Id == produto.Id);

            if (item == null)
            {
                _itensCarrinhos.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
                item.Quantidade += quantidade;
        }

        public void RemoverItem(Produto produto)
        {
            _itensCarrinhos.RemoveAll(l => l.Produto.Id == produto.Id);
        }

        public decimal ObterValorTotal()
        {
            return _itensCarrinhos.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        public void LimparCarrinho()
        {
            _itensCarrinhos.Clear();
        }

    }
}
