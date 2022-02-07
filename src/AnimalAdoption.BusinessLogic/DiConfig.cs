using AnimalAdoption.BusinessLogic.Services.Animal;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.BusinessLogic
{
    public static class DiConfig
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAnimalService, AnimalService>();

        }
    }
}
