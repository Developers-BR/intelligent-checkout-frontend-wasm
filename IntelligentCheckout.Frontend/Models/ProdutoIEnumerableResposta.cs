using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Models
{
    public class ProdutoIEnumerableResposta : Resposta
    {
        public List<Produto> Data { get; set; }
    }
}
