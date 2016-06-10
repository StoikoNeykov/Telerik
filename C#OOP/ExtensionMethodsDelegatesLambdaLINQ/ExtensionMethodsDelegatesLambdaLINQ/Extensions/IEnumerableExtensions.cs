namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

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

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }

        // Better dont read below this line ! 

        public static T AllIn<T>(this IEnumerable<T> collection, Func<T, T, T> func)
        {
            T result = default(T);
            foreach (var item in collection)
            {
                result = func(result, item);
            }
            return result;
        }

        public static T AllAfterFirst<T>(this IEnumerable<T> collection, Func<T, T, T> func)
        {
            T result = collection.FirstOrDefault();
            foreach (var item in collection.Skip(1))
            {
                result = func(result, item);
            }
            return result;
        }

        public static T AnotherMySum<T>(this IEnumerable<T> collection)
        {
            return AllIn(collection, (x, sum) => sum = Add(sum, x));
        }

        public static T AnotherMyProduct<T>(this IEnumerable<T> collection)
        {
            return AllAfterFirst(collection, (x, prod) => prod = Multyply(prod, x));
        }

        public static T AnotherMyMin<T>(this IEnumerable<T> collection) where T : IComparable
        {
            return AllAfterFirst(collection, (x, min) => min.CompareTo(x) < 0 ? min : x);
        }

        public static T AnotherMyMax<T>(this IEnumerable<T> collection) where T : IComparable
        {
            return AllAfterFirst(collection, (x, max) => max.CompareTo(x) > 0 ? max : x);
        }

        // !! Returns T - that mean Average of int is int
        public static T AnotherMyAverage<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            return MyTAverage(collection.AnotherMySum(), collection.Count());
        }

        private static T Add<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "b");
            BinaryExpression body = Expression.Add(paramA, paramB);
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            return add(a, b);
        }

        private static T Multyply<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "b");
            BinaryExpression body = Expression.Multiply(paramA, paramB);
            Func<T, T, T> multyply = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            return multyply(a, b);
        }

        private static T MyTAverage<T>(T a, int b) where T : IConvertible
        {
            T converted = (T)Convert.ChangeType(b, typeof(T));
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(T), "b");
            BinaryExpression body = Expression.Divide(paramA, paramB);
            Func<T, T, T> avrg = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            return avrg(a, converted);
        }
    }
}
