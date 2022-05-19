using System.Linq;

namespace AnimalAdoption.BusinessLogic.Helpers.SortHelper
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}
