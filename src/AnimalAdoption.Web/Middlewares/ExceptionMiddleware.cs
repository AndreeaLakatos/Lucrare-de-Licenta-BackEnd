using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Exceptions;
using AnimalAdoption.BusinessLogic.Utils;
using Microsoft.AspNetCore.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AnimalAdoption.Web.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
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
            var message = new StringBuilder();
            message.AppendLine(exception.Message);

            ErrorCode errorCode;
            int httpStatusCode;

            switch (exception)
            {
                 case UserValidationException:
                     errorCode = ErrorCode.UserAlreadyExist;
                     httpStatusCode = StatusCodes.Status422UnprocessableEntity;
                     break;
                default:
                    errorCode = ErrorCode.SomethingWentWrong;
                    httpStatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var exceptionErrorCode = Enum.TryParse(exception.Data[StringLiterals.Exceptions.ErrorCodeKey]?.ToString(),
                out ErrorCode error);
            if (exceptionErrorCode)
            {
                errorCode = error;
                httpStatusCode = StatusCodes.Status400BadRequest;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = httpStatusCode;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var errorResponse = new ErrorResponse(errorCode, message.ToString());

            var response = JsonSerializer.Serialize(errorResponse, options);

            await httpContext.Response.WriteAsync(response);
        }
    }
}
