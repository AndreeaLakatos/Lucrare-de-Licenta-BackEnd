using System;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AnimalAdoption.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<BasicUser> _userManager;

        public AccountService(UserManager<BasicUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult<BasicUser>> Register(RegisterUserDto registerUserDto)
        {

            var userExists = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (userExists != null)
            {
                throw new Exception("This user already exist!");
            }

            var user = new BasicUser
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("BasicUser registration fails!");
            }

            await _userManager.AddToRoleAsync(user, "BasicUser");

            return user;
        }
    }
}
