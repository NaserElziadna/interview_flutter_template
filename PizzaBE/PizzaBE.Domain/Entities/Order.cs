using PizzaBE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Entities
{
    public class Order : BasicEntity<int>
    {
        public Product Product { get; set; }
        
        public OrderState State { get; set; }
       
    }
}
