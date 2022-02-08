using Api.Commons.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Utils
{
    public static class ApiMapperBuilder
    {

        public static IMapper CreateDefaultMap()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] { typeof(ApiMapper) });
            });

            return mapperConfig.CreateMapper();
        }
    }
}
