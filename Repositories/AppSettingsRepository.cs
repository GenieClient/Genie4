using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Repositories
{
    public class AppSettingsRepository : BaseSettingsRepository<AppSettings>
    {
        public AppSettingsRepository(IConfiguration config):base(config){}
    }
}
