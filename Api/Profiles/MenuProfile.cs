using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;
using retail_backend.Data.Helpers;

namespace retail_backend.Api.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Order, OrderShortReadDto>()
                .ForMember(d => d.StatusName, opt => opt.MapFrom(s => DataConstants.OrderStatusDict[s.Status]));
        }
    }
}