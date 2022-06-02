using EFCoreTestApp.Dal;
using EFCoreTestApp.Models;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTestApp
{
    public class Startup
    { 
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionsString = Configuration["ConnectionStrings:DefaultConnection"];
            string customerConnectionsString = Configuration["ConnectionStrings:CustomerConnection"];
            services.AddDbContext<EFDatabaseContext>(a => a.UseSqlServer(connectionsString));
            services.AddDbContext<EFCustomerContext>(a => a.UseSqlServer(customerConnectionsString));

            services.AddControllersWithViews();

            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<MigrationsManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EFDatabaseContext prodCtx, EFCustomerContext custCtx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Данные методы используются для автоматического заполнения БД данными (БД должна быть пустой)
                SeedData.Seed(prodCtx);
                SeedData.Seed(custCtx);
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
