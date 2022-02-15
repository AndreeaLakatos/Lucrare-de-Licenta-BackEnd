using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAdoption.Web.Services.Account
{
    public interface IAccountService
    {
        Task<ActionResult<BasicUser>> Register(RegisterUserDto registerUserDto);

    }
}
