using AutoMapper;
using Location.Data;
using Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Mapping
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<Country, DetailsCountryViewModel>().ReverseMap();
            CreateMap<Country, CreateCountryViewModel>().ReverseMap();
            CreateMap<Area, DetailsAreaViewModel>().ReverseMap();
            CreateMap<Area, CreateAreaViewModel>().ReverseMap();
            CreateMap<City, DetailsCityViewModel>().ReverseMap();
            CreateMap<City, CreatCityViewModel>().ReverseMap();

        }
    }
}
