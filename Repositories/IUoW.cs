using GenieClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Repositories
{
    public interface IUoW
    {
        ISettingsRepository<AppSettings> AppSettingsRepository { get; set; }
    }
}
