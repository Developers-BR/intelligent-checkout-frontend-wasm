using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public class ProdutoIEnumerableResposta : Resposta
    {
        public ProdutoIEnumerableResposta(List<Aviso> avisos, Erro erro, List<Produto> data) : base(avisos, erro)
        {
            Data = data;
        }

        public List<Produto> Data { get; private set; }
    }
}
