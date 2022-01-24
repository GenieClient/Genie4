using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ScriptSettings : BaseSettings
    {
        public int MaxGoSubDepth { get; set; } = 50;
        public int Timeout { get; set; } = 5000;
        public bool IgnoreWarnings { get; set; } = false;
        public bool AbortDuplicates { get; set; } = true;

        //public static implicit operator ScriptSettings(string json)
        //{
        //    return JsonConvert.DeserializeObject<ScriptSettings>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

        //public string ListValues()
        //{
        //    string list = $"\nScript Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"MaxGoSubDepth:\t {MaxGoSubDepth}\n";
        //    list += $"Timeout:\t\t {Timeout}\n";
        //    list += $"IgnoreWarnings:\t {IgnoreWarnings}\n";
        //    list += $"AbortDuplicates:\t {AbortDuplicates}\n";
        //    return list;
        //}
    }
}
