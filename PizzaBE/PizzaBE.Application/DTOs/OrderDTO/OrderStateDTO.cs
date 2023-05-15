using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.DTOs.OrderDTO
{
    public enum OrderStateDTO
    {
        Created,
        Accepted,
        InProgress,
        Cancelled,
        Delivered,
        Done
    }
}
