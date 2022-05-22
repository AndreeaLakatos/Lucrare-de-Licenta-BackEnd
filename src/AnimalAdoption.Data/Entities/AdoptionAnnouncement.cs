using System.Collections.Generic;

namespace AnimalAdoption.Data.Entities
{
    public class AdoptionAnnouncement
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public string MoreDetails { get; set; }
        public bool Status { get; set; }
        public string FromDate { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; }
    }
}
