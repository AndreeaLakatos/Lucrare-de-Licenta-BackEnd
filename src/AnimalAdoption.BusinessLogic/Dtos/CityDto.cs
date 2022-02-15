namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountyDto County { get; set; }
    }
}
