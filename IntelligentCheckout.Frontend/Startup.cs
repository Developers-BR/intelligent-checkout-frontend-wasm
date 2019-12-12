using Blazored.LocalStorage;
using BlazorStrap;
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
            services.AddBootstrapCSS();
            services.AddSingleton<CartService>();
            services.AddSingleton<PessoaService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
