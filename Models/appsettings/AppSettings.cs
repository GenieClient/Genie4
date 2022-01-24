using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class AppSettings : BaseSettings
    {
        public ClientSettings ClientSettings { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }
        public IEnumerable<GameInstance> GameInstances { get; set; }

        //public static implicit operator AppSettings(string json)
        //{
        //    return JsonConvert.DeserializeObject<AppSettings>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}
    }
}
