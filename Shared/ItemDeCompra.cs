using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public sealed class ItemDeCompra
    {
        public ItemDeCompra(Guid idProduto, int quantidade)
        {
            IdProduto = idProduto;
            Quantidade = quantidade;
        }

        public Guid IdProduto { get; private set; }
        public int Quantidade { get; private set; }
    }
}
