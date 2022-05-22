using System;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class FosteringRequestListModelDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CountyDto County { get; set; }
        public CityDto City { get; set; }
        public string Street { get; set; }
        public string Reason { get; set; }
        public DateTime AvailableDate { get; set; }
        public string SomethingElse { get; set; }
        public bool Status { get; set; }
        public int FosteringAnnouncementId { get; set; }
        public bool Reviewed { get; set; }
        public string FromDate { get; set; }
        public string Username { get; set; }
    }
}
