using AnimalAdoption.BusinessLogic.Helpers.PagedList;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AnimalAdoption.BusinessLogic.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationMetaData paginationMetaData)
        {
            response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
        }
    }
}
