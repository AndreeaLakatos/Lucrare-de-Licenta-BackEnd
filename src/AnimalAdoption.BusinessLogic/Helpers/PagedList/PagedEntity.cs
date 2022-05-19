using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoption.BusinessLogic.Helpers.PagedList
{
    public class PagedEntity<T>
    {
        public PaginationMetaData PaginationMetaData { get; }
        public List<T> Result { get; }

        public PagedEntity(IEnumerable<T> items, int pageNumber, int pageSize, int count)
        {
            PaginationMetaData = new PaginationMetaData(pageNumber, pageSize, count, (int)Math.Ceiling(count / (double)pageSize));
            Result = items.ToList();
        }

        public static PagedEntity<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var result = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var count = source.Count();
            return new PagedEntity<T>(result, pageNumber, pageSize, count);
        }
    }
}