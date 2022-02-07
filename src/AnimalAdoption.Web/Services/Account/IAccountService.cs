using System.Threading.Tasks;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Services.Account
{
    public interface IAccountService
    {
        Task<ActionResult<User>> Register(RegisterUserDto registerUserDto);
    }
}
