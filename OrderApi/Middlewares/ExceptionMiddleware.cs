using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using OrderApi.Http.Model;

namespace OrderApi.Middlewares
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
                context.Response.WriteAsJsonAsync(httpException.Message).Wait();
            }
        }

    }
}