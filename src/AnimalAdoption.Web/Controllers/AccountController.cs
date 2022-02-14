using System;
using System.Threading.Tasks;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Controllers.Base;
using AnimalAdoption.Web.Dtos.UserDtos;
using AnimalAdoption.Web.Services.Account;
using AnimalAdoption.Web.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoption.Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _authenticateService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService authenticateService, ITokenService tokenService)
        {
            _authenticateService = authenticateService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<BasicUser>> RegisterUser(RegisterUserDto registerUserDto) => Ok(await _authenticateService.Register(registerUserDto));

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoggedInUserDto>> Login(LoginUserDto loginUserDto)
        {
            var token = await _tokenService.CreateToken(loginUserDto);

            if (string.IsNullOrEmpty(token))
                throw new Exception("Wrong username or password!");

            return new LoggedInUserDto
            {
                Username = loginUserDto.Username,
                Token = token,
            };
        }

    }
}
