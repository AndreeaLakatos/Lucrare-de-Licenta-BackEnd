namespace AnimalAdoption.BusinessLogic.Helpers.PagedList
{
    public class PaginationMetaData
    {
        public PaginationMetaData() { }
        public PaginationMetaData(in int pageNumber, in int pageSize, in int totalCount, int totalPages)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }

}
