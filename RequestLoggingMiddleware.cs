using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UserManagementAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Log request
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // Log response
            stopwatch.Stop();
            Console.WriteLine($"Response: {context.Response.StatusCode} Time taken: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
