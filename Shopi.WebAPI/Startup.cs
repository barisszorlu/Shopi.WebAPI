using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopi.Repository;
using Shopi.WebAPI.Middleware;
using ShopiWebAPI.Dependencies;
using System;
using Shopi.WebAPI.Extensions;
using Shopi.Cqrs.Configuration;

namespace Shopi.WebAPI
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddServiceDependency();
            services
                .AddLogic(Configuration)
                .AddMediatR(typeof(LogicServiceCollectionExtensions).Assembly)
                ;
            services.AddDbContext<MemoryDBContext>(options => options.UseInMemoryDatabase(databaseName: "MemoryDB").ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
            services.AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopi.WebApi");
                c.RoutePrefix = String.Empty;
            });

            app.UseHttpsRedirection();
            app.UseGlobalException();
            app.UseCustom(new CustomOptions
            {
                MaxSizeForPostContent = 2048
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
