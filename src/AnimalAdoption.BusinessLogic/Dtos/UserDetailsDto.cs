namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class UserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public CountyDto County { get; set; }
        public CityDto City { get; set; }
        public string Street { get; set; }
    }
}
