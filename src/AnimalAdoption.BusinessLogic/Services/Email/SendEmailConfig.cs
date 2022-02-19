using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalAdoption.BusinessLogic.Services.Email
{
    public static class SendEmailConfig
    {
        public static void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ISendEmailService, SendEmailService>();

            serviceCollection.Configure<EmailOptions>(options =>
            {
                options.ApiKey = configuration["ExternalProviders:Email:ApiKey"];
                options.SenderEmail = configuration["ExternalProviders:Email:SenderEmail"];
                options.SenderName = configuration["ExternalProviders:Email:SenderName"];
                options.TemplateIdWelcome = configuration["ExternalProviders:Email:TemplateId-Welcome"];
                options.TemplateIdForget = configuration["ExternalProviders:Email:TemplateId-Forget"];
            });
        }
    }
}
