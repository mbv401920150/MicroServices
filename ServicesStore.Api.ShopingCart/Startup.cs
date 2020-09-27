using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServicesStore.Api.ShopingCart.App;
using ServicesStore.Api.ShopingCart.Persistence;
using ServicesStore.Api.ShopingCart.RemoteInterface;
using ServicesStore.Api.ShopingCart.RemoteService;

namespace ServicesStore.Api.ShopingCart
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
            services.AddScoped<ILibraryBookService, LibraryBookService>();
            services.AddControllers();
            services.AddDbContext<AppDbContext>(opt => opt.UseMySQL(Configuration.GetConnectionString("MySql")));
            services.AddMediatR(typeof(ShoppingCartNew.ShoppingCartHandler));

            services.AddHttpClient("Books", config => {
                config.BaseAddress = new Uri(Configuration["Services:Books"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}