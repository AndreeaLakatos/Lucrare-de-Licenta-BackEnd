using System;
using System.Net;
using System.Threading.Tasks;
using AnimalAdoption.Web.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AnimalAdoption.Web.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        private const string _concatenator = ", ";

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                BadHttpRequestException => exception.Message,
                WebException => exception.Message,
                _ => exception.Message
            };

            var stack = exception switch
            {
                BadHttpRequestException => exception.StackTrace,
                WebException => exception.StackTrace,
                _ => exception.StackTrace
            };

            await httpContext.Response.AddErrorMessage(httpContext.Response.StatusCode, message, stack);
        }
    }
}
