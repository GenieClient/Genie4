using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoMapper;

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

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();

            var services = host.Services;
            var formMain = services.GetRequiredService<FormMain>();

            Application.Run(formMain);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<FormMain>();
            services.AddAutoMapper(typeof(MapProfile));

            //Going to inject configuration into FormMain for now... but when we revisit this code should maybe go here.
            //List<LichSetting> lichSettings = configuration.GetSection("LichSettings").Get<List<LichSetting>>();

            //Register services here. 
            //Example... Service.AddSingleton(Interface, Service);
        }
    }
}
