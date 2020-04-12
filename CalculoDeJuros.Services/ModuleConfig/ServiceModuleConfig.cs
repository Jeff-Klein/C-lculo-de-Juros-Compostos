using Autofac;
using CalculoDeJuros.Business.Services;
using Microsoft.Extensions.Configuration;

namespace CalculoDeJuros.Business.ModuleConfig
{
    public class ServiceModuleConfig : Module
    {
        public IConfiguration Configuration { get; set; }

        public ServiceModuleConfig() { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TaxaDeJurosService>().AsImplementedInterfaces();
            builder.RegisterType<CalculoDeJurosService>().AsImplementedInterfaces();
        }
    }
}
