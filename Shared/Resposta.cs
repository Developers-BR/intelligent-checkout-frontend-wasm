using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Shared
{
    public class Resposta
    {
        public Resposta(List<Aviso> avisos, Erro erro)
        {
            Avisos = avisos;
            Erro = erro;
        }

        public List<Aviso> Avisos { get; private set; }
        public Erro Erro { get; private set; }
    }
}
