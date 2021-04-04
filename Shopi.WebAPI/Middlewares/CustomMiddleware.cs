using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopi.WebAPI.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CustomOptions _options;
        private readonly ILogger _logger = Log.ForContext<CustomMiddleware>();

        public CustomMiddleware(RequestDelegate next, IOptions<CustomOptions> options, ILogger logger)
        {
            _next = next;
            _options = options.Value;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            if (request.Method == "POST")
            {
                var contentLength = request.ContentLength;
                Console.WriteLine("[{0}]:{1}-{2}", DateTime.Now.ToLongTimeString(), request.Method, request.Path);

                if (contentLength > _options.MaxSizeForPostContent)
                {
                    _logger.Information("POST işlemi sırasında limit ihlali : {0} bytes\nLimit->{1}", contentLength, _options.MaxSizeForPostContent);
                }
                else
                {
                    _logger.Information("OK ({0})", contentLength);
                }
                string logMessage = $"{context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode + " " + DateTime.Now.ToString()}{Environment.NewLine}";
                _logger.Information(logMessage);
            }
            await _next.Invoke(context);
        }
    }
}
