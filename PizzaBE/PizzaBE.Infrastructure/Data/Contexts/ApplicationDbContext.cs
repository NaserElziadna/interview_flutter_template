using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Int64>
    {
        private IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<PizzaWorkerUser> PizzaWorkerUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> PizzaProducts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PizzaBE.Infrastructure"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
