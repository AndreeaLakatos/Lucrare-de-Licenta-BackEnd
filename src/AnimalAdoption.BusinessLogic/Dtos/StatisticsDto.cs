namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class StatisticsDto
    {
        public int AdoptionAnnouncementsCount { get; set; }
        public int ActiveAdoptionAnnouncements { get; set; }
        public int ClosedAdoptionAnnouncements { get; set; }
        public int AdoptionRequestsNumber { get; set; }
        public float AdoptionAverage { get; set; }
        public int FosteringAnnouncementsCount { get; set; }
        public int ActiveFosteringAnnouncements { get; set; }
        public int ClosedFosteringAnnouncements { get; set; }
        public int FosteringRequestsNumber { get; set; }
        public float FosteringAverage { get; set; }
        public int AdoptionUsersNo { get; set; }
        public int AcceptedAdoptionRequests { get; set; }
        public int RejectedAdoptionRequests { get; set; }
        public int FosteringUsersNo { get; set; }
        public int AcceptedFosteringRequests { get; set; }
        public int RejectedFosteringRequests { get; set; }
    } 
}
