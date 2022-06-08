using AnimalAdoption.Data.Entities;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class UserPreferencesDto
    {
        public bool Open { get; set; }
        public bool RequestSent { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
