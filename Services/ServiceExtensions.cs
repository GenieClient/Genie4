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
        /// Uses null (no-op) implementations by default - platform-specific code should
        /// replace these with real implementations.
        /// </summary>
        public static IServiceCollection AddGenieServices(this IServiceCollection services)
        {
            // Core infrastructure services
            services.AddSingleton<IPathService, PathService>();

            // Platform-agnostic service interfaces with null implementations by default
            // Platform-specific projects (Genie.Windows, Genie.Avalonia) override via
            // WindowsServiceInitializer.Initialize() or similar
            services.AddSingleton<ISoundService>(NullSoundService.Instance);
            services.AddSingleton<IWindowAttentionService>(NullWindowAttentionService.Instance);
            services.AddSingleton<IRichTextService>(NullRichTextService.Instance);
            services.AddSingleton<IImageService>(NullImageService.Instance);
            services.AddSingleton<IWindowChromeService>(NullWindowChromeService.Instance);
            services.AddSingleton<IColorParsingService>(NullColorParsingService.Instance);

            // Game services - GameServiceAdapter wraps the existing Game class
            // Note: GameServiceAdapter requires Game and Globals instances, which are 
            // currently created in FormMain. Full DI registration will happen when 
            // FormMain is refactored. For now, FormMain can create the adapter manually:
            //
            //   var gameService = new GameServiceAdapter(m_oGame, m_oGlobals);
            //
            // Future: Once Globals is also a service:
            // services.AddSingleton<Globals>();
            // services.AddSingleton<Game>();
            // services.AddSingleton<IGameService, GameServiceAdapter>();
            // services.AddSingleton<ICommandService, CommandServiceAdapter>();

            return services;
        }
    }
}

