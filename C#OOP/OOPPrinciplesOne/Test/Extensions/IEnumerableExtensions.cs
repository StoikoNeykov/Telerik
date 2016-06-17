namespace Test.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalHierarchy.Models;

    public static class IEnumerableExtensions
    {

        /// <summary>
        /// easier way to apply action of coleections
        /// </summary>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }

        /// <summary>
        /// Cals Average age
        /// </summary>
        /// <typeparam name="T"> Animal </typeparam>
        /// <param name="action"> Filter animals by type </param>
        public static double Avrg<T>(this IEnumerable<T> collection, Func<T, T> action) where T : Animal
        {
            var result = collection
                .Select(x => action(x))
                .Where(x => x != null)
                .Select(x => x.Age)
                .Average();
            return result;
        }
    }
}