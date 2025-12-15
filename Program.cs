using GenieClient.Services;
using GenieClient.Windows.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace GenieClient
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Windows-specific services (sound, window attention, etc.)
            // This registers Windows implementations with the GenieServices static locator
            WindowsServiceInitializer.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();

            var services = host.Services;
            var formMain = services.GetRequiredService<FormMain>();
            formMain.DirectConnect(args);
            Application.Run(formMain);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // Register core platform-agnostic services
            services.AddGenieServices();

            // Register Windows Forms UI
            services.AddSingleton<FormMain>();
        }
    }
}
