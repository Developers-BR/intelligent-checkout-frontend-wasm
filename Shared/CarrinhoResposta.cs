using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public sealed class CarrinhoResposta : Resposta
    {
        public CarrinhoResposta(List<Aviso> avisos, Erro erro, Carrinho data) : base(avisos, erro)
        {
            Data = data;
        }

        public Carrinho Data { get; private set; }
        
    }
}
