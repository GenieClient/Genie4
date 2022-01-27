using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ScriptSettings : BaseSettings
    {
        public int ScriptSettingsId { get; set; }
        public int MaxGoSubDepth { get; set; }
        public int Timeout { get; set; }
        public bool IgnoreWarnings { get; set; } 
        public bool AbortDuplicates { get; set; }    

    }
}
