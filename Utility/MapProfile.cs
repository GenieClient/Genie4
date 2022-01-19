using AutoMapper;
using GenieClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<GameInstance, LichSettings>();
        }
    }
}
