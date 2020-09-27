using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServicesStore.Api.Author.App;
using ServicesStore.Api.Author.Persistence;

namespace ServicesStore.Api.Author
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
            services.AddControllers()
                .AddFluentValidation(
                    cfg => cfg.RegisterValidatorsFromAssemblyContaining<NewAuthorBook>()
                );

            services.AddDbContext<ContextAuthor>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostGres"));
            });

            // JUST ONE TIME
            // The service when start a class, automatically will scan the other classes into the project
            services.AddMediatR(typeof(NewAuthorBook.Handler).Assembly);

            services.AddAutoMapper(typeof(GetListAuthorBook.ListAuthorBook));
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
