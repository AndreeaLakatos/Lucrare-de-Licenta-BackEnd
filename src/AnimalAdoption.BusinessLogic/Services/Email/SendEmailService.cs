using System.Threading.Tasks;
using AnimalAdoption.Data.Entities;
using EllipticCurve.Utils;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AnimalAdoption.BusinessLogic.Services.Email
{
    public class SendEmailService: ISendEmailService
    {
        public EmailOptions Options { get; set; }
        public SendEmailService(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }

        public async Task SendForgetPasswordEmail(BasicUser basicUser) => await Execute(Options.ApiKey, basicUser, "forget");

        public async Task SendWelcomeEmail(BasicUser basicUser) => await Execute(Options.ApiKey, basicUser);

        private async Task<Response> Execute(string apiKey, BasicUser basicUser, string type="")
        {
            var client = new SendGridClient(apiKey);
            var templateId = Options.TemplateIdWelcome;

            var dynamicTemplateData = new EmailModel
            {
                FirstName = basicUser.FirstName,
                LastName = basicUser.LastName,
            };
            if (type == "forget")
            {
                dynamicTemplateData.PasswordCode = basicUser.PasswordCode;
                templateId = Options.TemplateIdForget;
            }

            var from = new EmailAddress(Options.SenderEmail, Options.SenderName);
            var to = new EmailAddress(basicUser.Email);

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);

            return await client.SendEmailAsync(msg);
        }
    }
}
