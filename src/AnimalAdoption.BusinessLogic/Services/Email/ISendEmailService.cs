using AnimalAdoption.Data.Entities;
using System.Threading.Tasks;

namespace AnimalAdoption.BusinessLogic.Services.Email
{
    public interface ISendEmailService
    {
        Task SendForgetPasswordEmail(BasicUser basicUser, EmailModel emailContent);
        Task SendWelcomeEmail(BasicUser basicUser);
    }
}
