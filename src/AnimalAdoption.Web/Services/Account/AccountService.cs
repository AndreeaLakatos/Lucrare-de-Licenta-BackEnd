using AnimalAdoption.BusinessLogic.Dtos;
using AnimalAdoption.BusinessLogic.Exceptions;
using AnimalAdoption.BusinessLogic.Services.Email;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalAdoption.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<BasicUser> _userManager;
        private readonly AnimalAdoptionDbContext _dbContext;
        private readonly ISendEmailService _sendEmailService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<BasicUser> userManager, AnimalAdoptionDbContext dbContext, ISendEmailService sendEmailService, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _sendEmailService = sendEmailService;
            _mapper = mapper;
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
                UserPreferences = null
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

        public async Task<UserPreferencesDto> GetUserPreferences(string username)
        {
            var user = await _dbContext.AppUsers.Include(x => x.UserPreferences).FirstOrDefaultAsync(user => user.UserName == username);
            var x =  _mapper.Map<UserPreferencesDto>(user.UserPreferences);
            return x;
        }

        public async Task<UserDetailsDto> GetUserDetails(string username)
        {
            var user = await _dbContext.AppUsers
                .Include(x => x.Address).ThenInclude(x => x.City)
                .Include(x => x.Address).ThenInclude(x => x.County)
                .FirstOrDefaultAsync(user => user.UserName == username);

            return new UserDetailsDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                County = _mapper.Map<CountyDto>(user.Address.County),
                City = _mapper.Map<CityDto>(user.Address.City),
                Street = user.Address.Street
            };
        }

        public async Task<UserDetailsDto> SaveUserDetails(UserDetailsDto userDetails)
        {
            var user = await _dbContext.AppUsers
                .Include(x => x.Address).ThenInclude(x => x.County)
                .Include(x => x.Address).ThenInclude(x => x.City)
                .FirstOrDefaultAsync(x => x.UserName == userDetails.UserName);
            var county = await _dbContext.Counties.FirstOrDefaultAsync(x => x.Name == userDetails.County.Name);
            var city = await _dbContext.Cities.Include(x => x.County).FirstOrDefaultAsync(x => x.Name == userDetails.City.Name && x.County.Name == userDetails.County.Name);

            user.PhoneNumber = userDetails.PhoneNumber;
            user.Address = new Address
            {
                County = county,
                City = city,
                Street = userDetails.Street
            };
            _dbContext.Addresses.Add(user.Address);
            user.FirstName = userDetails.FirstName;
            user.LastName = userDetails.LastName;

            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddUserPreferencesException, "Invalid user preferences!");
            }

            return new UserDetailsDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                County = _mapper.Map<CountyDto>(user.Address.County),
                City = _mapper.Map<CityDto>(user.Address.City),
                Street = user.Address.Street
            };
        }

        public async Task<UserPreferencesDto> SaveUserPreferences(string username, UserPreferencesDto userPreferences)
        {
            var userPref = await _dbContext.AppUsers.Include(x => x.UserPreferences).FirstOrDefaultAsync(x => x.UserName == username);
            userPref.UserPreferences = _mapper.Map<UserPreferences>(userPreferences);
            if (userPref == null)
                _dbContext.UserPreferencess.Add(userPref.UserPreferences);
            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddUserPreferencesException, "Invalid user preferences!");
            }
            return userPreferences;

        }

        public async Task<NgoDetailsDto> GetNgoDetails(string username)
        {
            var user = await _dbContext.Ngos
                .Include(x => x.NgoAddress).ThenInclude(x => x.City)
                .Include(x => x.NgoAddress).ThenInclude(x => x.County)
                .FirstOrDefaultAsync(user => user.UserName == username);

            return new NgoDetailsDto
            {
                NgoName = user.NgoName,
                Code = user.Code,
                NgoCounty = _mapper.Map<CountyDto>(user.NgoAddress.County),
                NgoCity = _mapper.Map<CityDto>(user.NgoAddress.City),
                NgoStreet = user.NgoAddress.Street
            };
        }

        public async Task<NgoDetailsDto> SaveNgoDetails(string username, NgoDetailsDto ngoDetailsDto)
        {
            var ngo = await _dbContext.Ngos
                .Include(x => x.Address).ThenInclude(x => x.County)
                .Include(x => x.Address).ThenInclude(x => x.City)
                .FirstOrDefaultAsync(x => x.UserName == username);
            var county = await _dbContext.Counties.FirstOrDefaultAsync(x => x.Name == ngoDetailsDto.NgoCounty.Name);
            var city = await _dbContext.Cities.Include(x => x.County).FirstOrDefaultAsync(x => x.Name == ngoDetailsDto.NgoCity.Name && x.County.Name == ngoDetailsDto.NgoCounty.Name);

            ngo.NgoName = ngoDetailsDto.NgoName;
            ngo.NgoAddress = new Address
            {
                County = county,
                City = city,
                Street = ngoDetailsDto.NgoStreet
            };
            _dbContext.Addresses.Add(ngo.NgoAddress);
            ngo.Code = ngoDetailsDto.Code;

            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                throw new AddException(ErrorCode.AddUserPreferencesException, "Invalid user preferences!");
            }

            return ngoDetailsDto;
        }
    }
}
