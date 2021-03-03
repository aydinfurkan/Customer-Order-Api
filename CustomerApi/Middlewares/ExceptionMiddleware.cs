using System;
using System.Threading.Tasks;
using CustomerApi.Http.Model;
using Microsoft.AspNetCore.Http;

namespace CustomerApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = (int) httpException.HttpStatusCode;
                context.Response.ContentType = "application/json";
                context.Response.WriteAsync(httpException.Message).Wait();
            }
            catch (Exception exception)
            {
                Console.WriteLine("ASDASD"); // TODO Async controller
                Console.WriteLine(exception);
            }
        }

    }
}