namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public CityDto City { get; set; }
        public CountyDto County { get; set; }
    }
}
