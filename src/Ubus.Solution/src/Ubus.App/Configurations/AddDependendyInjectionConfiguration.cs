using Microsoft.Extensions.DependencyInjection;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;
using Ubus.Data.Repositories;

namespace Ubus.App.Configurations
{
    public static class AddDependendyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<UbusContext>();

            /* Repositories */
            services.AddScoped<IViagemRepository, ViagemRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<IMotoristaViagemRepository, MotoristaViagemRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAdicionalRepository, AdicionalRepository>();
            services.AddScoped<IRotaRepository, RotaRepository>();

            /* Services */


            /* Notifications */
            //services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
