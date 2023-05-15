using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Entities
{
    public class CustomerUser : ApplicationUser
    {
        public string CustomerProperty { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
