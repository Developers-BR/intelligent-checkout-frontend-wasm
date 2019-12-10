using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCheckout.Frontend.Models
{
    public class Resposta
    {
        public List<Aviso> Avisos { get; set; }
        public Erro Erro { get; set; }
    }
}
