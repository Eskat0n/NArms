using System.Collections.Generic;
using System.Linq;

namespace NArms.Collections.Extensions
{
    public static class IsEmptyExtensions
    {
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> collection)
        {
            return collection.Any() == false;
        }
    }
}