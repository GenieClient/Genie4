using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ClientSettings : BaseSettings
    {
        public int ClientSettingsId { get; set; } 
        public int BufferLineSize { get; set; }
        public string Editor { get; set; }
        public bool IgnoreCloseAlert { get; set; }
        public int MaxArguments { get; set; }
        public string Prompt { get; set; }
        public SpecialCharacters SpecialCharacters { get; set; }
        public ScriptSettings ScriptSettings { get; set; }
    }
}
