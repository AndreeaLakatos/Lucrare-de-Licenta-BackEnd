using AnimalAdoption.Data.Entities;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class UserPreferencesDto
    {
        public bool HasFamily { get; set; }
        public bool HaveChildren { get; set; }
        public string LivingPlace { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
