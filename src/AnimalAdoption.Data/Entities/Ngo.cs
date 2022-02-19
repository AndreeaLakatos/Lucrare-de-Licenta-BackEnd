using System;
using System.Collections.Generic;

namespace AnimalAdoption.Data.Entities
{
    public class Ngo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<Animal> Animal { get; set; }
    }
}
