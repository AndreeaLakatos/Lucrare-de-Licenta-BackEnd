using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAdoption.Web.Services.Account
{
    public interface IAccountService
    {
        Task<ActionResult<BasicUser>> RegisterBasicUser(RegisterUserDto registerUserDto);
        Task<ActionResult<BasicUser>> RegisterNgo(RegisterNgoDto registerNgoDto);
        Task ForgotPassword(ForgotPasswordDto forgotPasswordDto);
        Task ResetPassword(ResetPasswordDto resetPasswordDto);

    }
}
