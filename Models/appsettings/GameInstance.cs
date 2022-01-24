using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class GameInstance :BaseSettings
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ConnectionString { get; set; }
        public double RTOffset { get; set; }
        public string ActivityCommand { get; set; }
        public int ActivityTimeout { get; set; }
        public int LichPort { get; set; }
        public string LichArguments { get; set; }

        //public static implicit operator GameInstance(string json)
        //{
        //    return JsonConvert.DeserializeObject<GameInstance>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

        //public string ListValues()
        //{
        //    string list = $"\nGame Instance Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"Name:\t\t\t {Name}\n";
        //    list += $"Code:\t\t\t {Code}\n";
        //    list += $"ConnectionString:\t {ConnectionString}\n";
        //    list += $"RTOffset:\t\t {RTOffset}\n";
        //    list += $"ActivityCommand:\t {ActivityCommand}\n";
        //    list += $"ActivityTimeout:\t {ActivityTimeout}\n";
        //    list += $"LichPort:\t\t {LichPort}\n";
        //    list += $"LichArguments:\t {LichArguments}\n";
        //    return list;
        //}

        public static IEnumerable<GameInstance> DefaultValues()
        {
            List<GameInstance> gameInstances = new List<GameInstance>
            {
                new GameInstance() { Name = "Prime", Code = "DR", LichPort = 11024, LichArguments = "--genie --dragonrealms"},
                new GameInstance() { Name = "Fallen", Code = "DRF", LichPort = 11324, LichArguments = "--genie --fallen" },
                new GameInstance() { Name = "Platinum", Code = "DRX", LichPort = 11124, LichArguments = "--genie --platinum --dragonrealms" },
                new GameInstance() { Name = "Test", Code = "DRT", LichPort = 11624, LichArguments = "--genie --test --dragonrealms" }
            };

            return gameInstances;
        }
    }
}
