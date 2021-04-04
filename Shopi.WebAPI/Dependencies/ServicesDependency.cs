using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Shopi.Business;
using Shopi.Cqrs.Commands;
using Shopi.Cqrs.Queries;
using Shopi.Cqrs.Validators;
using Shopi.Repository;
using Shopi.WebAPI;

namespace ShopiWebAPI.Dependencies
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IReflectionSorter, ReflectionSorter>();
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddTransient<IValidator<GetOrderByFilterQuery>, FilterOrderValidator>();
            services.AddTransient<IValidator<CreateOrderListCommand>, OrderListValidator>();

        }
    }
}
