using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Models
{
    public class Carrinho
    {
        public Guid IdSessao { get; set; }
        public List<ItemDeCompra> ItemsDeCompra { get; set; }
        public int QuantidadeDeItens { get; set; }
        public decimal ValorTotalDoCarrinho { get; set; }
    }
}
