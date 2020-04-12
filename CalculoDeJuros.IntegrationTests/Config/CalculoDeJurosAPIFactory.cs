using Autofac.Extensions.DependencyInjection;
using CalculoDeJuros.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculoDeJuros.IntegrationTests.Config
{
    public class CalculoDeJurosAPIFactory<T> : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var builder = WebHost.CreateDefaultBuilder()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();

            return builder;
        }
    }
}
