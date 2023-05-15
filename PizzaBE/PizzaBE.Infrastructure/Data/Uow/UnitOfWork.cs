using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow;
using PizzaBE.Domain.Interfaces.Uow.Repositories;
using PizzaBE.Infrastructure.Data.Contexts;
using PizzaBE.Infrastructure.Data.Uow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UnitOfWork(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context,
            IMapper _mapper,
            IMemoryCache memoryCache)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

            Orders = new OrderRepository(_context, memoryCache);
            Products = new ProductRepository(_context, memoryCache);
            Customers = new CustomerRepository(_context, memoryCache);

        }

        public IOrderRepository Orders { get; private set; }

        public IProductRepository Products { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync() > 0);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SeedDataAsync()
        {
            var resultString = "";

            await this._createInitialRoles();
            resultString += "<p>[Roles] created </p>";

            await this._createInitialUsers();
            resultString += "<p>[Users] created, and added to Admin role </p>";


            resultString += "<p>[Done] </p>";

            await SaveChangesAsync();
        }

        private async Task<bool> _createInitialRoles()
        {

            String[] initilaRoles = { "worker", "user" };

            foreach (String roleName in initilaRoles)
            {
                bool isExist = await _roleManager.RoleExistsAsync(roleName);

                if (!isExist)
                {

                    // first we create Admin rool    
                    var role = new ApplicationRole();
                    role.Name = roleName;
                    await _roleManager.CreateAsync(role);

                }
            }
            return true;
        }

        private async Task<bool> _createInitialUsers()
        {

            try
            {
                var user = new PizzaWorkerUser { title = "admin", UserName = "admin@admin.com", Email = "admin@admin.com" };
                var result = await _userManager.CreateAsync(user, "1!Qaz2@Wsx");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "worker");
                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
