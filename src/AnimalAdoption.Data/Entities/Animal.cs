using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalAdoption.Data.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalType AnimalType { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public int NgoId { get; set; }

        [ForeignKey("NgoId")]
        public Ngo Ngo { get; set; }
    }
}
