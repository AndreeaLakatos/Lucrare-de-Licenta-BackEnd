using AnimalAdoption.BusinessLogic.Services.Ngos;
using AnimalAdoption.BusinessLogic.Services.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.BusinessLogic
{
    public static class DiConfig
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<INgoService, NgoService>();
            serviceCollection.AddScoped<IUtilsService, UtilsService>();
        }
    }
}
