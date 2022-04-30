using AnimalAdoption.Data.Entities;
using System;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class FosteringAnnouncementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MoreDetails { get; set; }
        public string Username { get; set; }
    }
}
