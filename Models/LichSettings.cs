using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Models
{
    public class LichSettings
    {
        public string ProfileName { get; set; } = "default";
        public string RubyPath { get; set; } = @"C:\\ruby4lich\\bin\\ruby.exe";
        public string CmdPath { get; set; } = @"C:\\Windows\\System32\\cmd.exe";
        public string LichPath { get; set; } = @"C:\\ruby4lich\\lich\\lich.rbw";
        public string LichArguments { get; set; } = "--genie --dragonrealms";
        public string LichServer { get; set; } = "localhost";
        public int LichPort { get; set; } = 11024;
        public int LichStartPause { get; set; } = 5;
    }
}
