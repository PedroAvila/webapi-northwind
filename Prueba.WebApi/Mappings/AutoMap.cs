using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.WebApi
{
    public static class AutoMap
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            //var mapperConfiguration = new MapperConfiguration(
            //   config =>
            //   {
            //       config.AddProfile<UserProfile>();
            //   });

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

            Mapper = configuration.CreateMapper();
        }
    }
}