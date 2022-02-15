﻿using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.Data.Entities;
using AutoMapper;

namespace AnimalAdoption.BusinessLogic.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<County, CountyDto>().ReverseMap();
        }
    }
}
