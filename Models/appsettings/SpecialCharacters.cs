using System;
using Newtonsoft.Json;
namespace GenieClient.Models
{
    public class SpecialCharacters : BaseSettings
    {
        public char Command { get; set; } = '#';
        public char Separator { get; set; } = ';';
        public char Script { get; set; } = '.';
        public char Send { get; set; } = '-';
        public char Parse { get; set; } = '/';

        //public static implicit operator SpecialCharacters(string json)
        //{
        //    return JsonConvert.DeserializeObject<SpecialCharacters>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
        //public string ListValues()
        //{
        //    string list = $"\nSpecial Characters\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"Command:\t\t {Command}\n";
        //    list += $"Separator:\t\t {Separator}\n";
        //    list += $"Script:\t\t\t {Script}\n";
        //    list += $"Send:\t\t\t {Send}\n";
        //    list += $"Parse:\t\t\t {Parse}\n";
        //    return list;
        //}
    }
}
