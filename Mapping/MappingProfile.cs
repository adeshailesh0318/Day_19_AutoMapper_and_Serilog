using AutoMapper;
using Day19_AutoMapper_Serilog.DTOs;
using Day19_AutoMapper_Serilog.Models;

namespace Day19_AutoMapper_Serilog.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}