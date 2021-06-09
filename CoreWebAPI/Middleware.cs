using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project.
    // Add Middleware into Request Pipeline in Confifure method of Startup.cs
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public Middleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Middleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");
            await _next(httpContext); // calling next middleware
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
