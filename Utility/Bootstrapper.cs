using GenieClient.Models;
using GenieClient.Repositories;
using GenieClient.Services;
using Microsoft.Extensions.DependencyInjection;


namespace GenieClient
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddSingleton<IGenieSettingsService, GenieSettingsService>();

            //Infrastructure Layer
            services.AddAutoMapper(typeof(MapProfile));

            //Data Layer
            services.AddSingleton<ISettingsRepository<AppSettings>, AppSettingsRepository>();
            services.AddSingleton<IUoW, UoW>();

            //UI Layer
            services.AddSingleton<FormMain>();
        }
    }
}
