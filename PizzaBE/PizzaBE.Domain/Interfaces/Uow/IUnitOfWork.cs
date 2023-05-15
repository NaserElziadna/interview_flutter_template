using PizzaBE.Domain.Interfaces.Uow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Interfaces.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }

        Task SeedDataAsync(); // method for seeding data

        int Complete();

        Task<bool> SaveChangesAsync();
    }
}
