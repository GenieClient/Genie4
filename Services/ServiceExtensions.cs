using Microsoft.Extensions.DependencyInjection;

namespace GenieClient.Services
{
    /// <summary>
    /// Extension methods for registering Genie services with DI.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registers all core Genie services with the DI container.
        /// </summary>
        public static IServiceCollection AddGenieServices(this IServiceCollection services)
        {
            // Core infrastructure services
            services.AddSingleton<IPathService, PathService>();
            services.AddSingleton<ISoundService, SoundService>();

            // TODO: Add more services as they are extracted:
            // services.AddSingleton<IConnectionService, ConnectionService>();
            // services.AddSingleton<IGameService, GameService>();
            // services.AddSingleton<ICommandService, CommandService>();

            return services;
        }
    }
}

