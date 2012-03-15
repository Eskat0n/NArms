namespace NArms.Collections.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IsEmptyExtensions
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            return enumerable == null || enumerable.IsEmpty();
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            var list = enumerable as IList<TSource>;
            if (list != null)
                return list.Count == 0;

            var collection = enumerable as ICollection<TSource>;
            if (collection != null)
                return collection.Count == 0;

            return enumerable.Any() == false;
        }

        public static bool IsNotEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            if (enumerable == null)
                return false;

            var list = enumerable as IList<TSource>;
            if (list != null)
                return list.Count != 0;

            var collection = enumerable as ICollection<TSource>;
            if (collection != null)
                return collection.Count != 0;

            return enumerable.Any();
        }
    }
}