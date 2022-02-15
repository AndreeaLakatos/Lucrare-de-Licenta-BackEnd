using AnimalAdoption.BusinessLogic.Services.Animal;
using AnimalAdoption.BusinessLogic.Services.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.BusinessLogic
{
    public static class DiConfig
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAnimalService, AnimalService>();
            serviceCollection.AddScoped<IUtilsService, UtilsService>();

        }
    }
}
