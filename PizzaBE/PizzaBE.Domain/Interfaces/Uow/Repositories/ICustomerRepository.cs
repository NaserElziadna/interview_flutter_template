using PizzaBE.Domain.Base;
using PizzaBE.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Interfaces.Uow.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerUser>
    {
        List<Order> GetAllOrders(long userId);
    }
}