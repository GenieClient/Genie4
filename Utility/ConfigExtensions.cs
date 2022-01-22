using GenieClient.Models;
using System.Text.Json;
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

        public static void SaveProfiles(this IConfiguration config)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(config);
            string s = json;
        }

        public static IEnumerable<GameInstance> LoadGameInstances(this IConfiguration config)
        {
            return config.GetSection("GameInstances").Get<IEnumerable<GameInstance>>();
        }
    }
}
