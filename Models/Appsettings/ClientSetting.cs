using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ClientSetting : BaseSettings
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int BufferLineSize { get; set; }
        public string Editor { get; set; }
        public bool IgnoreCloseAlert { get; set; }
        public int MaxArguments { get; set; }
        public string Prompt { get; set; }
        public char Command { get; set; }
        public char Separator { get; set; }
        public char Script { get; set; }
        public char Send { get; set; }
        public char Parse { get; set; }
        public int ScriptSettingsId { get; set; }
        public int MaxGoSubDepth { get; set; }
        public int Timeout { get; set; }
        public bool IgnoreWarnings { get; set; }
        public bool AbortDuplicates { get; set; }

    }
}
