using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow.Repositories;
using PizzaBE.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Uow.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext _context,
            IMemoryCache memoryCache) : base(_context, memoryCache)
        {
        }


        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetAllDoneOrdersAsync()
        {
            return await _context.Orders.Where(o => o.State == OrderState.Done).ToListAsync();
        }

        public ApplicationDbContext _context
        {
            get { return Context; }
        }
    }
}
