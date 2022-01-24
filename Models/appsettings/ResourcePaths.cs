using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ResourcePaths : BaseSettings
    {
        public string Config { get; set; } = @"\Config";
        public string Icons { get; set; } = @"\Icons";
        public string Logs { get; set; } = @"\Logs";
        public string Maps{ get; set; } = @"\Maps";
        public string Plugins{ get; set; } = @"\Plugins";
        public string Scripts { get; set; } = @"\Scripts";
        public string Sounds{ get; set; } = @"\Sounds";
        public string Profile { get; set; } = @"\Config\Profiles\Default";

        //public static implicit operator ResourcePaths(string json)
        //{
        //    return JsonConvert.DeserializeObject<ResourcePaths>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}
        //public string ListValues()
        //{
        //    string list = $"\nResource Paths\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"Config:\t\t\t {Config}\n";
        //    list += $"Icons:\t\t\t {Icons}\n";
        //    list += $"Logs:\t\t\t {Logs}\n";
        //    list += $"Maps:\t\t\t {Maps}\n";
        //    list += $"Plugins:\t\t {Plugins}\n";
        //    list += $"Scripts:\t\t\t {Scripts}\n";
        //    list += $"Sounds:\t\t {Sounds}\n";
        //    list += $"Profile:\t\t\t {Profile}\n";
        //    return list;
        //}
    }
}
