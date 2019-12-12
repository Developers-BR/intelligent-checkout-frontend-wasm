using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Models
{
    public class ResultadoFinalizarCompra
    {
        public Guid Id { get; set; }
        public DateTime? DataHora { get; set; }
        public PessoaLogin Pessoa { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
