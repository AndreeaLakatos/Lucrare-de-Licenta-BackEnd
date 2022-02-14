using System;

namespace AnimalAdoption.Data.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
    }
}
