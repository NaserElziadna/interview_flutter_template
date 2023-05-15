using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow.Repositories;
using PizzaBE.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Uow.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext _context,
            IMemoryCache memoryCache) : base(_context, memoryCache)
        {
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.PizzaProducts.ToListAsync();
        }
        public ApplicationDbContext _context
        {
            get { return Context; }
        }
    }
}