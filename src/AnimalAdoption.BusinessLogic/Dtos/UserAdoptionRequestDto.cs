using System;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class UserAdoptionRequestDto
    {
        public int AnnouncementId { get; set; }
        public string Reason { get; set; }
        public string FromDate { get; set; }
        public string AvailableDate { get; set; }
        public string SomethingElse { get; set; }
        public bool Reviewed { get; set; }
        public bool Status { get; set; }
    }
}
