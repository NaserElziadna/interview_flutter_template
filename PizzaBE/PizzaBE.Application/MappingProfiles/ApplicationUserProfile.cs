using AutoMapper;
using PizzaBE.Application.DTOs.ApplicationUserDTO;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.MappingProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();

        }
    }
}
