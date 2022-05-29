using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using System.Threading.Tasks;
using AnimalAdoption.Web.Utils;

namespace AnimalAdoption.Web.Extensions
{
    public static class HttpExtensions
    {
        public static async Task AddErrorMessage(this HttpResponse response, int statusCode, string errorMessage, string errorStack)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage,
                ErrorStack = errorStack
            };
            await response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }
    }
}
