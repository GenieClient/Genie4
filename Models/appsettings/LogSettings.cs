using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class LogSettings : BaseSettings
    {
        public bool AutoLog { get; set; }  = true;

        //public static implicit operator LogSettings(string json)
        //{
        //    return JsonConvert.DeserializeObject<LogSettings>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}
        //public string ListValues()
        //{
        //    string list = $"\nLog Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"AutoLog:\t\t {AutoLog}\n";
        //    return list;
        //}

        
    }
}
