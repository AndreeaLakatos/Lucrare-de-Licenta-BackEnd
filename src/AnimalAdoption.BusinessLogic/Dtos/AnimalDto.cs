using System;
using AnimalAdoption.Data.Entities;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
    }
}
