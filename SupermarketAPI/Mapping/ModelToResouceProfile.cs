using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SupermarketAPI.Models;
using SupermarketAPI.Resources;

namespace SupermarketAPI.Mapping
{
    public class ModelToResouceProfile : Profile
    {
        public ModelToResouceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}
