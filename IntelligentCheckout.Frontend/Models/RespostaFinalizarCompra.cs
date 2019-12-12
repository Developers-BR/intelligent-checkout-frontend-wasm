using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Models
{
    public class RespostaFinalizarCompra : Resposta
    {
        public ResultadoFinalizarCompra Data { get; set; }
    }
}
