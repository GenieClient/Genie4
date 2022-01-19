using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Models
{
    public class GenieProfile
    {
        public string ProfileName { get; set; }
        public string ResourcePath { get; set; }
        public LichSettings LichSettings { get; set; }
        public string ProfileArg { get; set; }
    }
}
