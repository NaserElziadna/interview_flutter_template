using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Int64>
    {
        public String title { get; set; }
    }
}
