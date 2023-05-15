using AutoMapper;
using PizzaBE.Application.DTOs.OrderDTO;
using PizzaBE.Application.DTOs.ProductDTO;
using PizzaBE.Application.Interfaces;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddOrderAsync(OrderDTO model)
        {
            var mapped = _mapper.Map<Order>(model);

            _unitOfWork.Orders.Add(mapped);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangeOrderStatus(int orderId, OrderStateDTO status)
        {

            var order = GetOrder(orderId);
            if (order != null)
            {
                order.State = _mapper.Map<OrderState>(status);

                _unitOfWork.Orders.Update(order);

                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var res = GetOrder(orderId);
            if (res != null)
            {
                _unitOfWork.Orders.Remove(res);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            var all = await _unitOfWork.Orders.GetAllAsync();
            var mapped = _mapper.Map<List<OrderDTO>>(all);

            return mapped; 
        }

        public async Task<List<OrderDTO>> GetAllOrderByUser()
        {
            var user = await _userService.GetCurrenLoggedInUserAsync();
            var all = _unitOfWork.Customers.GetAllOrders(user.Id);
            var mapped = _mapper.Map<List<OrderDTO>>(all);

            return mapped;
        }

        private Order GetOrder(int id)
        {
            return _unitOfWork.Orders.SingleOrDefault(o => o.Id == id);
        }
    }
}
