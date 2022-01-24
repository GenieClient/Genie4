using GenieClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    public interface IGenieSettingsService
    {
        public AppSettings LoadSettings();
    }
}
