using AutoMapper;
using SwivelAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyAPI.Mappings
{
    public class StudentMappings : Profile
    {
        public StudentMappings()
        {
            CreateMap<StudentModelDto, StudentModel>().ReverseMap();
        }
    }
}
