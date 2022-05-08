using System;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class AdoptionRequestDto
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime AvailableDate { get; set; }
        public string SomethingElse { get; set; }
        public bool Status { get; set; }
        public bool Reviewed { get; set; }
        public int AdoptionAnnouncementId { get; set; }
        public string Username { get; set; }
    }
}
