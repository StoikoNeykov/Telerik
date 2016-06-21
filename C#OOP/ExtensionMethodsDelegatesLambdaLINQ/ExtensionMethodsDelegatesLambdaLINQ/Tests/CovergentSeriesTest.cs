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
            var result = Calculator.Calc(1000, x => x / 2);
            Console.WriteLine("{0:f2}", result);

            // 1, -1/2, 1/4, -1/8 ... 
            result = Calculator.Calc(1000, x => -x / 2);
            Console.WriteLine("{0:f2}", result);

            // 1/1! 1/2! 1/3! 1/4! ... 
            result = Calculator.Calc2(1000, (x, i) => x * (1 / i));
            Console.WriteLine("{0:f2}", result);
        }
    }
}
