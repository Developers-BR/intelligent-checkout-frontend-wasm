using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public sealed class Erro
    {
        public Erro(int numero, string mensagem)
        {
            Numero = numero;
            Mensagem = mensagem;
        }

        public int Numero { get; private set; }
        public string Mensagem { get; private set; }
    }
}
