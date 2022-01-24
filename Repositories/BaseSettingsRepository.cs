using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Repositories
{
    public abstract class BaseSettingsRepository<T> : ISettingsRepository<T> where T : class
    {
        private readonly IConfiguration config;
        public BaseSettingsRepository(IConfiguration config)
        {
            this.config = config;
        }

        public T GetConfig()
        {
            return this.config.GetSection($"{typeof(T).Name}").Get<T>(); ;
        }

        public void Save(AppSettings appSettings, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(appSettings);
            }
        }
        
    }
}
