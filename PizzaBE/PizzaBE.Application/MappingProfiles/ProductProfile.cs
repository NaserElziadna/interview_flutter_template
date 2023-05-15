using AutoMapper;
using PizzaBE.Application.DTOs.ApplicationUserDTO;
using PizzaBE.Application.DTOs.ProductDTO;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

        }
    }
}
