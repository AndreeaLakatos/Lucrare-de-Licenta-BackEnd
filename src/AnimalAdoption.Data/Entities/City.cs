namespace AnimalAdoption.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public County County { get; set; }
    }
}
