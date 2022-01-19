using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Models
{
    public class GameInstance
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int LichPort { get; set; }
        public string LichArguments { get; set; }
    }
}
