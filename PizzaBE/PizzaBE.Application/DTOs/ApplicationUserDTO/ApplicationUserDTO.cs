using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.DTOs.ApplicationUserDTO
{
    public class ApplicationUserDTO : IdentityUser<Int64>
    {
    }
}
