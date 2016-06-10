namespace ExtensionMethodsDelegatesLambdaLINQ.Tests
{
    using System;
    using System.Collections.Generic;
    using ExtensionMethodsDelegatesLambdaLINQ.Extensions;

    /// <summary>
    /// Class for testing IEnumerable<T> ext methods
    /// </summary>
    public static class IEnumerableTest
    {
        public static void Test()
        {
            Console.WriteLine("List of int");

            IEnumerable<int> someCollection = new List<int>() { 1, -6, 16, 8, 35 };
            Console.WriteLine(someCollection.MyMax());
            Console.WriteLine(someCollection.MyMin());
            Console.WriteLine(someCollection.MyProduct());
            Console.WriteLine(someCollection.MySum());
            Console.WriteLine(someCollection.MyAverage());

            Console.WriteLine("Array of double");

            IEnumerable<double> doubleArray = new[] { 1.3, 25, 23.8 };

            Console.WriteLine(doubleArray.MyMax());
            Console.WriteLine(doubleArray.MyMin());
            Console.WriteLine(doubleArray.MyProduct());
            Console.WriteLine(doubleArray.MySum());
            Console.WriteLine(doubleArray.MyAverage());

            // sick Tests - for extra methods that works with T operators (its extra testing and can be skipped)
            Console.WriteLine("--------------------" );
            Console.WriteLine(someCollection.AnotherMySum());
            Console.WriteLine(someCollection.AnotherMyProduct());
            Console.WriteLine(someCollection.AnotherMyMin());
            Console.WriteLine(someCollection.AnotherMyMax());
            // Average returns T 
            Console.WriteLine(someCollection.AnotherMyAverage());

            Console.WriteLine("--------------------");
            Console.WriteLine(doubleArray.AnotherMySum());
            Console.WriteLine(doubleArray.AnotherMyMax());
            Console.WriteLine(doubleArray.AnotherMyMin());
            Console.WriteLine(doubleArray.AnotherMyProduct());
            Console.WriteLine(doubleArray.AnotherMyAverage());
        }
    }
}
