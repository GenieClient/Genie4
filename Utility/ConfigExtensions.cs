using GenieClient.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient
{
    public static class ConfigExtensions
    {
        public static IEnumerable<GenieProfile> LoadProfiles(this IConfiguration config)
        {
            return config.GetSection("Profiles").Get<IEnumerable<GenieProfile>>();
        }

        public static IEnumerable<GameInstance> LoadGameInstances(this IConfiguration config)
        {
            return config.GetSection("GameInstances").Get<IEnumerable<GameInstance>>();
        }
    }
}
