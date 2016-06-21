namespace ExtensionMethodsDelegatesLambdaLINQ.CovergentSeries
{
    using System;

    /// <summary>
    /// Delegates training on covergent series
    /// </summary>
    public static class Calculator
    {
        // calculate given func few times and return result
        public static double Calc(int loops, Func<double, double> func)
        {
            double last = 1;
            double sum = 0;
            for (int i = 1; i < loops; i++)
            {
                sum += last;
                last = func(last);

            }
            return sum;
        }

        public static double Calc2(int loops, Func<double, double, double> func)
        {
            double last = 1;
            double sum = 0;
            for (int i = 1; i < loops + 1; i++)
            {

                last = func(last, i);
                sum += last;
            }
            return sum;
        }
    }
}
