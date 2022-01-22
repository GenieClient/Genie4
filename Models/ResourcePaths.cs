using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Models
{
    public class ResourcePaths
    {
        public string Config { get; set; } = @"\Config";
        public string Icons { get; set; } = @"\Icons";
        public string Logs { get; set; } = @"\Logs";
        public string Maps{ get; set; } = @"\Maps";
        public string Plugins{ get; set; } = @"\Plugins";
        public string Scripts { get; set; } = @"\Scripts";
        public string Sounds{ get; set; } = @"\Sounds";
    }
}
