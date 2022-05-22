namespace AnimalAdoption.BusinessLogic.Helpers.PagedList
{
    public class PaginationEntity
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchQuery { get; set; }
        public string Sizes { get; set; }
        public string Types { get; set; }
        public string Cities { get; set; }
        public string Status { get; set; }
        public string Others { get; set; }
    }
}
