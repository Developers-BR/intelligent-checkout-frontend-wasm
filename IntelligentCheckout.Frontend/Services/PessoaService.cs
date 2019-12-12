using Blazored.LocalStorage;
using IntelligentCheckout.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Services
{
    public class PessoaService
    {
        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        private Pessoa _pessoa;

        public Pessoa ObterPessoaAtual()
        {
            return _pessoa;
        }

        public void AtualizarPessoa(PessoaLogin login)
        {
            _pessoa = new Pessoa()
            {
                Id = login.Id,
                Nome = login.Nome,
                FotosDoRosto = login.FotosDoRosto.Select(f => f.FotoEmBase64).ToArray()
            };
            NotifyStateChanged();
        }
    }
}
