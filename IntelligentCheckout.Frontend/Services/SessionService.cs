using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Frontend.Services
{
    public class SessionService
    {
        private ILocalStorageService _localStorageService;

        public SessionService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        private const string SESSION_ID_KEY = "intelligent-checkout-session-id";

        public async Task<Guid> GetCurrentSessionIdOrNew()
        {
            Guid sessionId;

            if (!Guid.TryParse(await _localStorageService.GetItemAsync<string>(SESSION_ID_KEY), out sessionId))
            {
                sessionId = Guid.NewGuid();
                await _localStorageService.SetItemAsync(SESSION_ID_KEY, sessionId.ToString());
            }

            return sessionId;
        }
    }
}
