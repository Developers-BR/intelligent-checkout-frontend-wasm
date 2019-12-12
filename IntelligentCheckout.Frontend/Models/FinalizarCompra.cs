using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Models
{
    public class FinalizarCompra
    {
        public Guid IdSessao { get; set; }
        public string FotoDoRostoEmBase64 { get; set; }
    }
}
