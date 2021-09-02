using AutoMapper;
using BuildingTuts.Academy;
using BuildingTuts.AcademyStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingTuts
{
    public class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AcademyStudents, StudentDto>().ReverseMap();
            
        }
    }
}
