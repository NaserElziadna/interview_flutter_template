using PizzaBE.Application.DTOs.ApplicationUserDTO;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrenLoggedInUserAsync();
    }
}
