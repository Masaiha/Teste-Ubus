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


            /* Services */


            /* Notifications */
            //services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
