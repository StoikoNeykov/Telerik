namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static decimal MySum<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var result = collection
                .Select(x => Convert.ToDecimal(x))
                .Sum();
            return result;
        }

        public static decimal MyProduct<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));
            decimal result = 1;
            foreach (var number in decimalCollection)
            {
                result *= number;
            }
            return result;
        }

        public static decimal MyMin<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));
            var result = decimalCollection.FirstOrDefault();
            foreach (var number in decimalCollection)
            {
                if (number < result)
                {
                    result = number;
                }
            }
            return result;
        }

        public static decimal MyMax<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));
            var result = decimalCollection.FirstOrDefault();
            foreach (var number in decimalCollection)
            {
                if (number > result)
                {
                    result = number;
                }
            }
            return result;
        }

        public static decimal MyAverage<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            return collection.MySum() / collection.Count();
        }
    }
}
