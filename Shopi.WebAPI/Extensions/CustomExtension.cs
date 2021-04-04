using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopi.WebAPI.Middleware
{
    public static class CustomExtension
    {
        public static IApplicationBuilder UseCustom(this IApplicationBuilder app, CustomOptions options)
        {
            return app.UseMiddleware<CustomMiddleware>(Options.Create(options));
        }
    }
}
