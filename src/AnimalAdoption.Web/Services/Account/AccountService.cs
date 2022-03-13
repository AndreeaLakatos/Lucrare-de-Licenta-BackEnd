using System;
using System.Linq;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<BasicUser> _userManager;
        private readonly AnimalAdoptionDbContext _dbContext;

        public AccountService(UserManager<BasicUser> userManager, AnimalAdoptionDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<ActionResult<BasicUser>> Register(RegisterUserDto registerUserDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (userExists != null)
            {
                throw new UserValidationException(ErrorCode.UserAlreadyExist,"This user already exist!");
            }

            var county = await _dbContext.Counties.FirstOrDefaultAsync(county => county.Id == registerUserDto.County.Id);
            var city = await _dbContext.Cities.FirstOrDefaultAsync(city => city.Id == registerUserDto.City.Id);
            var address = new Address
            {
                Street = registerUserDto.Street,
                City = city,
                County = county
            };
            _dbContext.Addresses.Add(address);

            var userPreferences = new UserPreferences();
            _dbContext.UserPreferencess.Add(userPreferences);

            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddUserPreferencesException, "Invalid user preferences!");
            }

            var user = new BasicUser
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                Address = address,
                PhoneNumber = registerUserDto.PhoneNumber,
                PasswordCode = "",
                UserPreferences = userPreferences
            };

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("BasicUsers registration fails!");
            }

            await _userManager.AddToRoleAsync(user, "BasicUser");

            return user;
        }
    }
}
