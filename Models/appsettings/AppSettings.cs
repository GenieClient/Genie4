using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    [Serializable]
    public class AppSettings
    {
        public ClientSettings ClientSettings { get; set; } = new ClientSettings();
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<GameInstance> GameInstances { get; set; } = new List<GameInstance>();
        public static AppSettings CreateDefault()
        {
            AppSettings defaultConfig = new AppSettings();
            defaultConfig.GameInstances.Add(new GameInstance() { Name = "Prime", Code = "DR", LichPort = 11024, LichArguments = "--genie --dragonrealms"});
            defaultConfig.GameInstances.Add(new GameInstance() { Name = "Fallen", Code = "DRF", LichPort = 11324, LichArguments = "--genie --fallen" });
            defaultConfig.GameInstances.Add(new GameInstance() { Name = "Platinum", Code = "DRX", LichPort = 11124, LichArguments = "--genie --platinum --dragonrealms" });
            defaultConfig.GameInstances.Add(new GameInstance() { Name = "Test", Code = "DRT", LichPort = 11624, LichArguments = "--genie --test --dragonrealms" });
            defaultConfig.Profiles.Add(new Profile() { ResourcePaths = new ResourcePaths() { Profile = @"\Config\Profiles\Default" } });
            
            return defaultConfig;
        }
        public static AppSettings Load(string JsonFile)
        {
            if (File.Exists(JsonFile))
            {
                using (StreamReader sr = new StreamReader(JsonFile))
                {
                    return sr.ReadToEnd();
                }
            }
            else
            {
                return CreateDefault();
            }
        }

        public void Save(string Path)
        {
            using(StreamWriter sw = new StreamWriter(Path, false))
            {
                sw.WriteLine(this);
            }
        }

        public static implicit operator AppSettings(string json)
        {
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
