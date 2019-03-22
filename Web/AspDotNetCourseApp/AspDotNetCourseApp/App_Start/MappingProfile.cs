using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.Dtos;

namespace AspDotNetCourseApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}