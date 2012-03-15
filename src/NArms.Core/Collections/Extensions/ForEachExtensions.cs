namespace NArms.Collections.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class ForEachExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action action)
        {
            foreach (var item in collection)
                action();
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource> action)
        {
            foreach (var item in collection)
                action(item);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource, int> action)
        {
            var i = 0;
            foreach (var item in collection)
                action(item, i++);
        }

        public static void ForEach<TSource, TOut>(this IEnumerable<TSource> collection, Func<TSource, TOut> func)
        {
            foreach (var item in collection)
                func(item);
        }

        public static void ForEach<TSource, TOut>(this IEnumerable<TSource> collection, Func<TSource, int, TOut> func)
        {
            var i = 0;
            foreach (var item in collection)
                func(item, i++);
        }
    }
}