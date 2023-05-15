using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Entities
{
    public enum OrderState
    {
        Created,
        Accepted,
        InProgress,
        Cancelled,
        Delivered,
        Done
    }
}
