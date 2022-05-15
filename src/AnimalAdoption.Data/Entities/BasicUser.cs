using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AnimalAdoption.Data.Entities
{
    public class BasicUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; }
        public ICollection<FosteringRequest> FosteringRequests { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
