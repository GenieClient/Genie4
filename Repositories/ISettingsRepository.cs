using GenieClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Repositories
{
    public interface ISettingsRepository<T>
    {
        T GetConfig();
        void Save(AppSettings appSettings, string Path);
    }
}
