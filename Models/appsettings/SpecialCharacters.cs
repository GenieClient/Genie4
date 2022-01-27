using System;
using Newtonsoft.Json;
namespace GenieClient.Models
{
    public class SpecialCharacters : BaseSettings
    {
        public int SpecialCharactersId { get; set; }
        public char Command { get; set; }
        public char Separator { get; set; }
        public char Script { get; set; }
        public char Send { get; set; }
        public char Parse { get; set; }
    }
}
