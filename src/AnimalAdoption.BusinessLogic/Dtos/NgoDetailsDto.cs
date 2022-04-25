namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class NgoDetailsDto
    {
        public string NgoName { get; set; }
        public string Code { get; set; }
        public CountyDto NgoCounty { get; set; }
        public CityDto NgoCity { get; set; }
        public string NgoStreet { get; set; }
    }
}
