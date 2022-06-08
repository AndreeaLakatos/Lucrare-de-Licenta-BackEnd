namespace AnimalAdoption.Data.Entities
{
    public class UserPreferences
    {
        public int Id { get; set; }
        public bool Open { get; set; }
        public bool RequestSent { get; set; }
        public AnimalSize AnimalSize { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
