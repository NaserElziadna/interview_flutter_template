using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaBE.Application.Interfaces;
using PizzaBE.Application.MappingProfiles;
using PizzaBE.Application.Services;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow;
using PizzaBE.Infrastructure.Data.Contexts;
using PizzaBE.Infrastructure.Data.Uow;
using System.Collections.Generic;

namespace PizzaBE.RestApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddPizzaServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<ISetupService, SetupService>()
                .AddScoped<IAuthenticateService, AuthenticateService>();
        }

        public static IdentityBuilder AddMyIdentity(this IServiceCollection services)
        {

            var builder = services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //builder.AddUserStore<CustomerUser>();
            //builder.AddUserStore<PizzaWorkerUser>();

            return builder;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IMvcBuilder AddJsonHandler(this IMvcBuilder services)
        {
            return services.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }



        public static IServiceCollection AddMyAutoMapper(this IServiceCollection services, params System.Type[] profileAssemblyMarkerTypes)
        {
            var autoMapperServ = services.AddAutoMapper(typeof(Startup)); // configure AutoMapper

            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                // add profiles
                mc.AddProfiles(new List<Profile>
                {
                    new ProductProfile(),
                    new OrderProfile(),
                    new ApplicationUserProfile()
                });
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return autoMapperServ;
        }
    }
}
