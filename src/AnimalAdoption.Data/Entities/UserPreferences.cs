using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalAdoption.Data.Entities
{
    public class UserPreferences
    {
        public int Id { get; set; }
        public bool HasFamily { get; set; }
        public bool HasChildren { get; set; }
        public string LivingPlace { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
