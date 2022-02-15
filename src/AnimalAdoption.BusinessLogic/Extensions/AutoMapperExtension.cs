using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoption.BusinessLogic.Extensions
{
    public static class AutoMapperExtension
    {
        public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper,
            IEnumerable<TSource> source, Action<IMappingOperationOptions<TSource, TDestination>> options)
        {
            return source.Select(x => mapper.Map(x, options)).ToList();
        }
    }
}
