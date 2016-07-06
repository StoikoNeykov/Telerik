namespace Cosmetics.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }

        public static T AllIn<T>(this IEnumerable<T> collection, Func<T, T, T> func)
        {
            T result = default(T);
            foreach (var item in collection)
            {
                result = func(result, item);
            }
            return result;
        }
    }
}
