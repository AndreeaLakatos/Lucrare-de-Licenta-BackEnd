using System.ComponentModel.DataAnnotations;

namespace AnimalAdoption.Web.Dtos.UserDtos
{
    public class LoggedInUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
