using BlazorBootstrap.Modal;
using Blazored.LocalStorage;
using IntelligentCheckout.Frontend.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCheckout.Frontend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddBootstrapModal();
            services.AddSingleton<SessionService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
