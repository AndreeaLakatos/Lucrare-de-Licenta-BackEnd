using AnimalAdoption.BusinessLogic.Helpers.PagedList;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class GetAnnouncementsDto
    {
        public string Username { get; set; }
        public PaginationEntity PaginationEntity { get; set; }
    }
}
