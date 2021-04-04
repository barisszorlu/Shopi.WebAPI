using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shopi.Cqrs.Configuration
{
    public static class LogicServiceCollectionExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection container, IConfiguration config)
        {
            container.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            return container;
        }
    }
}
