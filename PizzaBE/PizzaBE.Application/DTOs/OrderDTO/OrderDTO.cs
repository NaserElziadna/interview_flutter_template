using PizzaBE.Application.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.DTOs.OrderDTO
{
    public class OrderDTO
    {
        public ProductDTO.ProductDTO product { get; set; }


        public OrderStateDTO state { get; set; }
    }
}
