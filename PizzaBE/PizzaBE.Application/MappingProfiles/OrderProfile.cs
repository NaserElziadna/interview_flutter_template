using AutoMapper;
using PizzaBE.Application.DTOs.OrderDTO;
using PizzaBE.Application.DTOs.ProductDTO;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderStateDTO, OrderState>();
            CreateMap<OrderState, OrderStateDTO>();

        }
    }
}
