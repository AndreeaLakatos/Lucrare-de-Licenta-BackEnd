using AnimalAdoption.BusinessLogic.Dtos;
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
        Task<UserDetailsDto> GetUserDetails(string username);
        Task<NgoDetailsDto> GetNgoDetails(string username);
        Task<UserPreferencesDto> GetUserPreferences(string username);
        Task<UserDetailsDto> SaveUserDetails(UserDetailsDto userDetails);
        Task<NgoDetailsDto> SaveNgoDetails(string username, NgoDetailsDto ngoDetailsDto);
        Task<UserPreferencesDto> SaveUserPreferences(string username, UserPreferencesDto userPreferences);
        Task<NotificationDto[]> GetUserNotifications(string username);

    }
}
