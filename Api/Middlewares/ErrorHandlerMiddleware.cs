using Api.Models.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiErrorResponse responseObject;

            switch(exception.GetType())
            {
                default:
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(exception.StackTrace);
                    context.Response.StatusCode = 500;
                    responseObject = new ApiErrorResponse("Erro Inesperado!");
                    break;
            }

            return context.Response.WriteAsJsonAsync(responseObject);
        }
    }
}