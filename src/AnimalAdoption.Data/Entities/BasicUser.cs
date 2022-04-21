using Microsoft.AspNetCore.Identity;

namespace AnimalAdoption.Data.Entities
{
    public class BasicUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Role { get; set; }
    }
}
