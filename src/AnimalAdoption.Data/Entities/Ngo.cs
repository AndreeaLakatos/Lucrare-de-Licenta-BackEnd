using System;
using System.Collections.Generic;

namespace AnimalAdoption.Data.Entities
{
    public class Ngo: BasicUser
    {
        public string NgoName { get; set; }
        public string Code { get; set; }
        public DateTime FoundedDate { get; set; }
        public Address NgoAddress { get; set; }
        public virtual ICollection<Animal> Animal { get; set; }
    }
}
