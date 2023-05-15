using PizzaBE.Application.DTOs.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAll();
        Task<List<OrderDTO>> GetAllOrderByUser();
        Task AddOrderAsync(OrderDTO model);
        Task ChangeOrderStatus(int orderId, OrderStateDTO status);
        Task DeleteOrderAsync(int orderId);
    }
}
