using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GenieClient.Models
{
    public class Profile :BaseSettings
    {
        public string ProfileName { get; set; } = "Default";
        public string GameInstanceCode { get; set; } = "DR";
        public string ActivityCommand { get; set; } = "quit";
        public int ActivityTimeout { get; set; } = 100;
        public bool AutoMapper { get; set; } = true;
        public bool GagsEnabled { get; set; } = true;
        public string IgnoreMonsterList { get; set; } = "appears dead|(dead)";
        public bool KeepInput { get; set; } = false;
        public bool ParseGameOnly { get; set; } = false;
        public bool PlaySounds { get; set; } = true;
        public bool Reconnect { get; set; } = true;
        public bool ReconnectWhenDead { get; set; } = false;
        public bool ShowCastBar { get; set; } = true;
        public bool ShowLinks { get; set; } = true;
        public bool ShowSpellTimer { get; set; } = true;
        public int TypeAhead { get; set; } = 2;
        public bool TriggerOnInput { get; set; } = true;
        public bool UseLich { get; set; } = false;
        public ResourcePaths ResourcePaths { get; set; } = new ResourcePaths();
        public LichSettings LichSettings { get; set; } = new LichSettings();
        public LogSettings LogSettings { get; set; } = new LogSettings();

        //public static implicit operator Profile(string json)
        //{
        //    return JsonConvert.DeserializeObject<Profile>(json);
        //}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

        //public string ListValues()
        //{
        //    string list = $"\nProfile Settings\n";
        //    list += $"----------------------------------------------------\n";
        //    list += $"ProfileName:\t\t {ProfileName}\n";
        //    list += $"GameInstanceCode:\t {GameInstanceCode}\n";
        //    list += $"ActivityCommand:\t {ActivityCommand}\n";
        //    list += $"ActivityTimeout:\t {ActivityTimeout}\n";
        //    list += $"AutoMapper:\t\t {AutoMapper}\n";
        //    list += $"IgnoreMonsterList:\t {IgnoreMonsterList}\n";
        //    list += $"KeepInput:\t\t {KeepInput}\n";
        //    list += $"ParseGameOnly:\t {ParseGameOnly}\n";
        //    list += $"PlaySounds:\t\t {PlaySounds}\n";
        //    list += $"Reconnect:\t\t {Reconnect}\n";
        //    list += $"ReconnectWhenDead:\t {ReconnectWhenDead}\n";
        //    list += $"ShowCastBar:\t\t {ShowCastBar}\n";
        //    list += $"ShowLinks:\t\t {ShowLinks}\n";
        //    list += $"ShowSpellTimer:\t {ShowSpellTimer}\n";
        //    list += $"TypeAhead:\t\t {TypeAhead}\n";
        //    list += $"TriggerOnInput:\t {TriggerOnInput}\n";
        //    list += $"UseLich:\t\t {UseLich}\n";
        //    list += ResourcePaths.ListValues();
        //    list += LichSettings.ListValues();
        //    list += LogSettings.ListValues();
        //    return list;
        //}

        public static IEnumerable<Profile> DefaultValues()
        {
            List<Profile> profiles = new List<Profile>
            {
                new Profile () { ResourcePaths = new ResourcePaths() { Profile = @"\Config\Profiles\Default" } }
            };

            return profiles;
        }

    }
}
