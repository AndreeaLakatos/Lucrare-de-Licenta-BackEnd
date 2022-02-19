using System;
using System.Collections.Generic;

namespace AnimalAdoption.Data.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public Animal Animal { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<FosterApplication> FosterApplication { get; set; }
    }
}
