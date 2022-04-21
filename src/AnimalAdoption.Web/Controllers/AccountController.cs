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
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<BasicUser>> RegisterUser(RegisterUserDto registerUserDto) => Ok(await _accountService.RegisterBasicUser(registerUserDto));

        [HttpPost]
        [Route("register-ngo")]
        public async Task<ActionResult<BasicUser>> RegisterNgo(RegisterNgoDto registerNgoDto) => Ok(await _accountService.RegisterNgo(registerNgoDto));

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

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            await _accountService.ForgotPassword(forgotPasswordDto);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            await _accountService.ResetPassword(resetPasswordDto);
            return Ok();
        }
    }
}
