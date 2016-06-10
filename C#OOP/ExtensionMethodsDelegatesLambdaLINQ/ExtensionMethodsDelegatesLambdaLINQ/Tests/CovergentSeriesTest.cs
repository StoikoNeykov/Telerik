namespace ExtensionMethodsDelegatesLambdaLINQ.Tests
{
    using System;

    /// <summary>
    /// Delegates testing
    /// </summary>
    using ExtensionMethodsDelegatesLambdaLINQ.CovergentSeries;

    public static class CovergentSeriesTest
    {
        public static void Test()
        {
            // 1, 1/2, 1/4, 1/8 .... 
            var result = Calculator.Calc(100000, (y, x) => 1 / x);
            Console.WriteLine("{0:f2}", result);

            // 1, -1/2, 1/4, -1/8 ... 
            result = Calculator.Calc(100000, (y, x) => x % 2 == 0 ? -1 / x : 1 / x);
            Console.WriteLine("{0:f2}", result);

            // 1! 2! 3! 4! ... 
            // Try with 100
            result = Calculator.Calc(1000, (y, x) => y * x);
            Console.WriteLine("{0:f2}", result);
        }
    }
}
