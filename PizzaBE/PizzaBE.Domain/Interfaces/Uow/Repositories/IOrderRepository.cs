using PizzaBE.Domain.Base;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Interfaces.Uow.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetAllDoneOrdersAsync();

    }
}
