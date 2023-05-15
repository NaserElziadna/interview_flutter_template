using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzaBE.RestApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBE.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
               .AddPizzaServices()
               .AddDatabase(Configuration)
               .AddUnitOfWork();
            services.AddMyIdentity();

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            services.AddControllers()
                .AddJsonHandler();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaBE.RestApi", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            services.AddMyAutoMapper(typeof(Startup));


            services.AddAuthentication()
               .AddCookie(cfg => { cfg.SlidingExpiration = true; })
               .AddJwtBearer(cfg =>
               {
                   cfg.RequireHttpsMetadata = false;
                   cfg.SaveToken = true;

                   cfg.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidIssuer = "Tokens:Issuer",
                       ValidAudience = "Tokens:Issuer",
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("I-Am-A-Key5244512e79775268374231315e41507e3f6e72734c40397a7b2851674b"))
                   };

               });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WenFee.RestApi v1"));
            }
            app.AddMyResposeWrapper();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
