using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoMapper;
using GenieClient.Repositories;
using GenieClient.Services;
using System.IO;
using GenieClient.Data;
using Microsoft.EntityFrameworkCore;

namespace GenieClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LocalDirectory.ConfigureUserDirectory();

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(LocalDirectory.SettingsPath);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();

 
            var services = host.Services;
            var context = services.GetRequiredService<GenieContext>();
            var formMain = services.GetRequiredService<FormMain>();

            context.Database.EnsureCreated();
            Application.Run(formMain);
        }

        private static IServiceCollection ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            Bootstrapper.RegisterServices(services, configuration);
            return services;
        }
    }
}
