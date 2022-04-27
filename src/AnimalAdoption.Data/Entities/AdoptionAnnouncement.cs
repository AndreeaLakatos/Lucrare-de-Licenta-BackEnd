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
        public ICollection<Photo> Images { get; set; }
    }
}
