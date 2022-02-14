using AnimalAdoption.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.Web.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }

        public static void AddExceptionMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ExceptionMiddleware>();
        }
    }
}
