using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketAPI.Extension;
using SupermarketAPI.Models;
using SupermarketAPI.Resources;

namespace SupermarketAPI.Mapping
{
    public class ModelToResouceProfile : Profile
    {
        public ModelToResouceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Products, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                    opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}
