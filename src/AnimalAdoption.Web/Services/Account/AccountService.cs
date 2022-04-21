using System;
using System.Linq;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AnimalAdoption.BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AnimalAdoption.BusinessLogic.Services.Email;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;

namespace AnimalAdoption.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<BasicUser> _userManager;
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly ISendEmailService _sendEmailService;

        public AccountService(UserManager<BasicUser> userManager, AnimalAdoptionDbContext dbContext, ISendEmailService sendEmailService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _sendEmailService = sendEmailService;
        }

        public async Task<ActionResult<BasicUser>> RegisterNgo(RegisterNgoDto registerNgoDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerNgoDto.UserName);
            if (userExists != null)
            {
                throw new UserValidationException(ErrorCode.UserAlreadyExist,"This user already exist!");
            }

            var county = await _dbContext.Counties.FirstOrDefaultAsync(county => county.Id == registerNgoDto.County.Id);
            var city = await _dbContext.Cities.FirstOrDefaultAsync(city => city.Id == registerNgoDto.City.Id);
            var address = new Address
            {
                Street = registerNgoDto.Street,
                City = city,
                County = county
            };

            var ngoCounty = await _dbContext.Counties.FirstOrDefaultAsync(county => county.Id == registerNgoDto.NgoCounty.Id);
            var ngoCity = await _dbContext.Cities.FirstOrDefaultAsync(city => city.Id == registerNgoDto.NgoCity.Id);
            var ngoAddress = new Address
            {
                Street = registerNgoDto.NgoStreet,
                City = ngoCity,
                County = ngoCounty
            };

            _dbContext.Addresses.Add(address);

            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddUserPreferencesException, "Invalid user preferences!");
            }

            var user = new Ngo
            {
                FirstName = registerNgoDto.FirstName,
                LastName = registerNgoDto.LastName,
                UserName = registerNgoDto.UserName,
                Email = registerNgoDto.Email,
                Address = address,
                PhoneNumber = registerNgoDto.PhoneNumber,
                Code = registerNgoDto.Code,
                NgoAddress = ngoAddress,
                NgoName = registerNgoDto.NgoName,
                FoundedDate = registerNgoDto.FoundedDate
            };

            var result = await _userManager.CreateAsync(user, registerNgoDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Ngo registration fails!");
            }

            await _userManager.AddToRoleAsync(user, "Ngo");

            return user;
        }

        public async Task<ActionResult<BasicUser>> RegisterBasicUser(RegisterUserDto registerUserDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (userExists != null)
            {
                throw new UserValidationException(ErrorCode.UserAlreadyExist, "This user already exist!");
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

            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                Address = address,
                PhoneNumber = registerUserDto.PhoneNumber,
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

        public async Task ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                throw new UserValidationException(ErrorCode.InvalidEmailAddress, "There is no user with this email address.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", forgotPasswordDto.Email }
            };
            var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            var message = new EmailModel
            {
                Message = callback
            };
            await _sendEmailService.SendForgetPasswordEmail(user, message);
        }

        public async Task ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                throw new UserValidationException(ErrorCode.InvalidEmailAddress, "There is no user with this email address.");

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                throw new UserValidationException(ErrorCode.InvalidPassword, "Invalid password");
            }
        }
    }
}
