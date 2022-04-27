using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.BusinessLogic.Services.Image
{
    public static class ImageConfig
    {
        public static void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IImageService, ImageService>();

            serviceCollection.Configure<CloudinaryOptions>(options =>
            {
                options.CloudinaryUrl = configuration["ExternalProviders:Image:CloudinaryUrl"];
                options.CloudName = configuration["ExternalProviders:Image:CloudName"];
                options.ApiKey = configuration["ExternalProviders:Image:ApiKey"];
                options.ApiSecret = configuration["ExternalProviders:Image:ApiSecret"];
            });
        }
    }
}
