using AutoMapper;
using Prueba.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WebApi
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CategoryExtend, CategoryDto>().ReverseMap();
        }
    }
}