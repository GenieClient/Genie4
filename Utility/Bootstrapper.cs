using GenieClient.Data;
using GenieClient.Models;
using GenieClient.Repositories;
using GenieClient.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GenieClient
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            //Application Layer
            services.AddScoped<IGenieSettingsService, GenieSettingsService>();

            //Infrastructure Layer
            services.AddAutoMapper(typeof(MapProfile));

            //Data Layer
            services.AddDbContext<GenieContext>(options => {
                options.UseSqlite(config.GetConnectionString("GenieDB"));
                });
            services.AddScoped<ISettingsRepository<AppSettings>, AppSettingsRepository>();
            services.AddScoped<IUoW, UoW>();

            //UI Layer
            services.AddSingleton<FormMain>();
        }
    }
}
