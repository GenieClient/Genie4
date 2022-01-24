using GenieClient.Models;
using GenieClient.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    public class GenieSettingsService : IGenieSettingsService
    {
        private IUoW uow;

        public GenieSettingsService(IUoW uow)
        {
            this.uow = uow;
        }

        public AppSettings LoadSettings()
        {
            AppSettings appSettings = uow.AppSettingsRepository.GetConfig();
            if (appSettings == null)
            {
                appSettings = GenerateDefaultAppSettings();
            }
            return appSettings;
        }

        public static AppSettings GenerateDefaultAppSettings()
        {
            var defaultConfig = new AppSettings();
            defaultConfig.GameInstances = GameInstance.DefaultValues();
            defaultConfig.Profiles = Profile.DefaultValues();
            return defaultConfig;
        }
    }
}
