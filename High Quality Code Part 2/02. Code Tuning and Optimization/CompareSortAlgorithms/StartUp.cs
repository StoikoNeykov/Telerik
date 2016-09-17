using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CompareSortAlgorithms
{
    public class StartUp
    {
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //be carefull with number of calls 
        private const int NumberOfCalls = 1;
        private const int StringLenght = 10;

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            SerialCaller(20);

            SerialCaller(100);

            SerialCaller(10000);
        }

        // Grouping methods

        /// <summary>
        /// Calling seria of test depending on array lenght
        /// </summary>
        /// <param name="curentCount">Array lenght</param>
        private static void SerialCaller(int curentCount)
        {
            // Random order
            SortingNumberOfRandoms<int>(GetRandomInts(curentCount),
                                            $"{curentCount} random ints");
            SortingNumberOfRandoms<double>(GetRandomDoubles(curentCount),
                                            $"{curentCount} random doubles");
            SortingNumberOfRandoms<string>(GetRandomStrings(curentCount, StringLenght),
                                            $"{curentCount} random strings");

            // Sorted order
            SortingNumberOfRandoms<int>(GetRandomInts(curentCount).OrderBy(x => x).ToArray(),
                                            $"{curentCount} sorted ints");
            SortingNumberOfRandoms<double>(GetRandomDoubles(curentCount).OrderBy(x => x).ToArray(),
                                            $"{curentCount} sorted doubles");
            SortingNumberOfRandoms<string>(GetRandomStrings(curentCount, StringLenght).OrderBy(x => x).ToArray(),
                                            $"{curentCount} sorted strings");

            // Reverse sorted
            SortingNumberOfRandoms<int>(GetRandomInts(curentCount).OrderByDescending(x => x).ToArray(),
                                            $"{curentCount} reverse sorted ints");
            SortingNumberOfRandoms<double>(GetRandomDoubles(curentCount).OrderByDescending(x => x).ToArray(),
                                            $"{curentCount} reverse sorted doubles");
            SortingNumberOfRandoms<string>(GetRandomStrings(curentCount, StringLenght).OrderByDescending(x => x).ToArray(),
                                            $"{curentCount} reverse sorted strings");
        }

        /// <summary>
        /// Run sorting few sorting algoritms on same array and display result in console
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="array">Original array</param>
        /// <param name="message">Explain what exactly testing</param>
        private static void SortingNumberOfRandoms<T>(T[] array, string message) where T : IComparable
        {
            var copy = new T[array.Length];

            Console.WriteLine($"Sorting {message}:");

            Array.Copy(array, copy, array.Length);
            Console.WriteLine($" InsertionSort: {Exec((arr) => InsertionSort(arr), copy, NumberOfCalls) }");

            Array.Copy(array, copy, array.Length);
            Console.WriteLine($" SelectionSort: {Exec((arr) => SelectionSort(arr), copy, NumberOfCalls)}");

            Array.Copy(array, copy, array.Length);
            Console.WriteLine($" QuickSOrt: {Exec((arr, start, end) => Quicksort(arr, start, end), copy, 0, copy.Length - 1, NumberOfCalls)}");

            Console.WriteLine();
        }

        // Sorting algoritms
        private static void InsertionSort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var value = arr[i];
                var j = i - 1;

                while ((j >= 0) && (arr[j].CompareTo(value) > 0))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = value;
            }
        }

        private static void SelectionSort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        private static void Quicksort<T>(T[] arr, int left, int right) where T : IComparable
        {
            int i = left, j = right;
            T pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort<T>(arr, left, j);
            }

            if (i < right)
            {
                Quicksort<T>(arr, i, right);
            }
        }

        // Generators
        private static int[] GetRandomInts(int count)
        {
            var result = new int[count];
            var rng = new Random();

            for (int i = 0; i < count; i++)
            {
                result[i] = rng.Next(100, 10000);
            }

            return result;
        }

        private static double[] GetRandomDoubles(int count)
        {
            var result = new double[count];
            var rng = new Random();

            for (int i = 0; i < count; i++)
            {
                result[i] = rng.Next(100, 10000) + ((double)rng.Next(100) / 100);
            }

            return result;
        }

        private static string[] GetRandomStrings(int count, int len)
        {
            var result = new string[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = GetRandomString(len);
            }

            return result;
        }

        private static string GetRandomString(int len)
        {
            var rng = new Random();
            var buffer = new char[len];

            for (int i = 0; i < len; i++)
            {
                buffer[i] = chars[rng.Next(chars.Length)];
            }

            return buffer.ToString();
        }

        // Measure
        private static TimeSpan Exec<T>(Action<T> act, T arr, int times)
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < times; i++)
            {
                act(arr);
            }

            watch.Stop();
            return watch.Elapsed;
        }

        private static TimeSpan Exec<T>(Action<T, int, int> act, T arr, int start, int end, int times)
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < times; i++)
            {
                act(arr, start, end);
            }

            watch.Stop();
            return watch.Elapsed;
        }
    }
}
