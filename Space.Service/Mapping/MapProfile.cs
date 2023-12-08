using AutoMapper;
using Space.Core.DTOs;
using Space.Core.Models;
using Space.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Planet,PlanetDto>().ReverseMap();
            CreateMap<Planet, PlanetPatchDto>().ReverseMap();
            CreateMap<Moon,MoonDto>().ReverseMap();
            CreateMap<Moon,MoonPatchDto>().ReverseMap();
            CreateMap<WeatherCondition, WeatherConditonDto>().ReverseMap();
        }
    }
}
