using System;

namespace AnimalAdoption.Data.Entities
{
    public class FosterApplication
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAdopted { get; set; }
    }
}
