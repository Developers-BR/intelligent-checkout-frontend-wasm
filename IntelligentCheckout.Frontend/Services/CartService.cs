using Blazored.LocalStorage;
using IntelligentCheckout.Frontend.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Services
{
    public class CartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        private const string SESSION_ID_KEY = "intelligent-checkout-session-id";

        public event Action OnChange;

        public CartService(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task<Guid> GetCurrentSessionIdOrNew()
        {
            if (!Guid.TryParse(await _localStorageService.GetItemAsync<string>(SESSION_ID_KEY), out Guid sessionId))
            {
                sessionId = Guid.NewGuid();
                await _localStorageService.SetItemAsync(SESSION_ID_KEY, sessionId.ToString());
            }

            return sessionId;
        }

        public async Task<Carrinho> GetCarrinho()
        {
            var sessionId = await GetCurrentSessionIdOrNew();
            var url = $"https://intelligent-checkout-backend.azurewebsites.net/api/carrinho/{sessionId}";
            var resposta = await _httpClient.GetJsonAsync<CarrinhoResposta>(url);

            return resposta.Data ?? new Carrinho() { IdSessao = sessionId };
        }

        public async Task<Carrinho> AdicionarItem(ItemDeCompra item)
        {
            var sessionId = await GetCurrentSessionIdOrNew();
            var url = $"https://intelligent-checkout-backend.azurewebsites.net/api/carrinho/{sessionId}";
            var data = new
            {
                IdProduto = item.Produto.Id.ToString(),
                Quantidade = item.Quantidade
            };

            await _httpClient.PostJsonAsync(url, data);

            NotifyStateChanged();
            return await GetCarrinho();
        }

        public async Task<Carrinho> AtualizarItem(ItemDeCompra item)
        {
            var sessionId = await GetCurrentSessionIdOrNew();
            var url = $"https://intelligent-checkout-backend.azurewebsites.net/api/carrinho/{sessionId}";
            var data = new
            {
                IdProduto = item.Produto.Id.ToString(),
                Quantidade = item.Quantidade
            };

            await _httpClient.PatchAsync(url, new StringContent(JsonConvert.SerializeObject(data)));

            NotifyStateChanged();
            return await GetCarrinho();
        }

        public async Task<Carrinho> RemoverItem(ItemDeCompra item)
        {
            var sessionId = await GetCurrentSessionIdOrNew();
            var idProduto = item.Produto.Id;
            var url = $"https://intelligent-checkout-backend.azurewebsites.net/api/carrinho/{sessionId}/{idProduto}";

            await _httpClient.DeleteAsync(url);

            NotifyStateChanged();
            return await GetCarrinho();
        }

        public async Task<Carrinho> LimparCarrinho()
        {
            var sessionId = await GetCurrentSessionIdOrNew();
            var url = $"https://intelligent-checkout-backend.azurewebsites.net/api/carrinho/{sessionId}";

            await _httpClient.DeleteAsync(url);

            NotifyStateChanged();
            return await GetCarrinho();
        }
    }
}

