using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalAdoption.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        public Task<ActionResult<User>> Register(RegisterUserDto registerUserDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
