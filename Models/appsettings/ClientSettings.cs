using System;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class ClientSettings : BaseSettings
    {
        public int BufferLineSize { get; set; } = 5;
        public string Editor { get; set; } = "notepad.exe";
        public bool IgnoreCloseAlert { get; set; } = false;
        public int MaxArguments { get; set; } = 15;
        public string Prompt { get; set; } = "> ";
        public SpecialCharacters SpecialCharacters { get; set; } = new SpecialCharacters();
        public ScriptSettings ScriptSettings { get; set; } = new ScriptSettings();

        //public static implicit operator ClientSettings(string json)
        //{
        //    return JsonConvert.DeserializeObject<ClientSettings>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}
        //public string ListValues()
        //{
        //    string list = $"\nClient Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"BufferLineSize:\t\t {BufferLineSize}\n";
        //    list += $"Editor:\t\t\t {Editor}\n";
        //    list += $"IgnoreCloseAlert:\t {IgnoreCloseAlert}\n";
        //    list += $"MaxArguments:\t {MaxArguments}\n";
        //    list += $"Prompt:\t\t {Prompt}\n";
        //    list += SpecialCharacters.ListValues();
        //    list += ScriptSettings.ListValues();
        //    return list;

        //}
    }




     
}
