using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public sealed class Carrinho
    {
        public Carrinho(Guid idSessao, List<ItemDeCompra> itemsDeCompra, int quantidadeDeItens, decimal valorTotalDoCarrinho)
        {
            IdSessao = idSessao;
            ItemsDeCompra = itemsDeCompra;
            QuantidadeDeItens = quantidadeDeItens;
            ValorTotalDoCarrinho = valorTotalDoCarrinho;
        }

        public Guid IdSessao { get; private set; }
        public List<ItemDeCompra> ItemsDeCompra { get; private set; }
        public int QuantidadeDeItens { get; private set; }
        public decimal ValorTotalDoCarrinho { get; private set; }
    }
}
