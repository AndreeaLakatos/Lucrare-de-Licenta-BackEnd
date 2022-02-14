using System.Threading.Tasks;
using AnimalAdoption.Web.Dtos.UserDtos;

namespace AnimalAdoption.Web.Services.Token
{
    public interface ITokenService
    {
        Task<string> CreateToken(LoginUserDto user);
    }
}
