using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class LichSettings : BaseSettings
    {
        public string ProfileName { get; set; } = "default";
        public string RubyPath { get; set; } = @"C:\ruby4lich\bin\ruby.exe";
        public string CmdPath { get; set; } = @"C:\Windows\System32\cmd.exe";
        public string LichPath { get; set; } = @"C:\ruby4lich\lich\lich.rbw";
        public string LichArguments { get; set; } = "--genie --dragonrealms";
        public string LichServer { get; set; } = "localhost";
        public int LichPort { get; set; } = 11024;
        public int LichStartPause { get; set; } = 5;

        //public static implicit operator LichSettings(string json)
        //{
        //    return JsonConvert.DeserializeObject<LichSettings>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}
        //public string ListValues()
        //{
        //    string list = $"\nLich Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"Cmd Path:\t\t {CmdPath}\n";
        //    list += $"Ruby Path:\t\t {RubyPath}\n";
        //    list += $"Lich Path:\t\t {LichPath}\n";
        //    list += $"Lich Arguments:\t {LichArguments}\n";
        //    list += $"Lich Start Pause:\t {LichStartPause}\n";
        //    list += $"Lich Server:\t\t {LichServer}\n";
        //    list += $"Lich Port:\t\t {LichPort}\n\n";
        //    return list;
        //}
    }
}
