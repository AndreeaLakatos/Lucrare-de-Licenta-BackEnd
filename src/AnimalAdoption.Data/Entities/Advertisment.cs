namespace AnimalAdoption.Data.Entities
{
    public class Advertisment
    {
        public int Id { get; set; }
        public Animal Animal { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
