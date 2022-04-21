using System.ComponentModel.DataAnnotations;

namespace AnimalAdoption.Web.Dtos.UserDtos
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientURI { get; set; }
    }
}
