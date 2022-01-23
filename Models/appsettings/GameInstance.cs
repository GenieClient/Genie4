using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    [Serializable]
    public class GameInstance
    {
        public string Name { get; set; } = "Prime";
        public string Code { get; set; } = "DR";
        public string ConnectionString { get; set; } = "FE:STORMFRONT /VERSION:1.0.1.26 /P:WIN_XP /XML";
        public double RTOffset { get; set; } = 0;
        public string ActivityCommand { get; set; } = "fatigue";
        public int ActivityTimeout { get; set; } = 180;
        public int LichPort { get; set; } = 11024;
        public string LichArguments { get; set; } = "--genie --dragonrealms";

        public static implicit operator GameInstance(string json)
        {
            return JsonConvert.DeserializeObject<GameInstance>(json);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public string ListValues()
        {
            string list = $"\nGame Instance Settings\n";
            list += $"----------------------------------------------------\n";
            list += $"Name:\t\t\t {Name}\n";
            list += $"Code:\t\t\t {Code}\n";
            list += $"ConnectionString:\t {ConnectionString}\n";
            list += $"RTOffset:\t\t {RTOffset}\n";
            list += $"ActivityCommand:\t {ActivityCommand}\n";
            list += $"ActivityTimeout:\t {ActivityTimeout}\n";
            list += $"LichPort:\t\t {LichPort}\n";
            list += $"LichArguments:\t {LichArguments}\n";
            return list;
        }
    }
}
