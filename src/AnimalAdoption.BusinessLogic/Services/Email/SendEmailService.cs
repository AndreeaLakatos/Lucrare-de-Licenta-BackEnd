using System.Threading.Tasks;
using AnimalAdoption.Data.Entities;
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

        public async Task SendForgetPasswordEmail(BasicUser basicUser, EmailModel emailContent) => await Execute(Options.ApiKey, basicUser, emailContent);

        public Task SendWelcomeEmail(BasicUser basicUser) => throw new System.NotImplementedException();

        private async Task<Response> Execute(string apiKey, BasicUser basicUser, EmailModel emailContent)
        {
            var client = new SendGridClient(apiKey);
            var templateId = Options.TemplateIdForget;

            var from = new EmailAddress(Options.SenderEmail, Options.SenderName);
            var to = new EmailAddress(basicUser.Email);

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, emailContent);

            return await client.SendEmailAsync(msg);
        }
    }
}
