using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AnimalAdoption.Data.Entities;
using AnimalAdoption.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AnimalAdoption.Web.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<BasicUser> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<BasicUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken(LoginUserDto user)
        {
            if (!(await ValidateUser(user)))
            {
                return null;
            }

            var us = await _userManager.FindByNameAsync(user.Username);
            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:ValidIssuer"],
               // audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: await GetAuthClaims(us),
                signingCredentials: new SigningCredentials(CreateAuthSingingKey(), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<bool> ValidateUser(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByNameAsync(loginUserDto.Username);
            return (user != null && await _userManager.CheckPasswordAsync(user, loginUserDto.Password));
        }

        private async Task<IEnumerable<Claim>> GetAuthClaims(BasicUser basicUser)
        {
            var userRoles = await _userManager.GetRolesAsync(basicUser);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, basicUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }

        private SymmetricSecurityKey CreateAuthSingingKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
    }
}
