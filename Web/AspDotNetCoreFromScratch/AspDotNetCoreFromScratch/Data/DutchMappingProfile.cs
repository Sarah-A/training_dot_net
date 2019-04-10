using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCoreFromScratch.ViewModels;
using AutoMapper;
using DutchTreat.Data.Entities;

namespace AspDotNetCoreFromScratch.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();
        }
        
    }
}
