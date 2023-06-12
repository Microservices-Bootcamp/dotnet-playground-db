﻿namespace Products.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {           
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("Bfore FirstMiddleware.....");
            return _next(httpContext);
        }
    }

    
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddlware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FirstMiddleware>();
        }
    }
}

