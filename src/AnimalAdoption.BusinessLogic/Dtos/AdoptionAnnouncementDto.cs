using AnimalAdoption.Data.Entities;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class AdoptionAnnouncementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public string MoreDetails { get; set; }
        public bool Status { get; set; }
        public string FromDate { get; set; }
        public string Username { get; set; }
    }
}
