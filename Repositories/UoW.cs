using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Repositories
{
    public class UoW : IUoW
    {
        private readonly IConfiguration config;
        private ISettingsRepository<AppSettings> appSettingsRepository;

        public UoW(IConfiguration config)
        {
            this.config = config;
        }

        public ISettingsRepository<AppSettings> AppSettingsRepository
        {
            get { 
                if (appSettingsRepository == null)
                {
                    appSettingsRepository = new AppSettingsRepository(config);
                }

                return appSettingsRepository;
            }
            set => appSettingsRepository = value;
        }
    }
}
