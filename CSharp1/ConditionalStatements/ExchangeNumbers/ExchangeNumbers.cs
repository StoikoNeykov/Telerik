namespace ConditionalStatements
{
    /// <summary>
    /// Program exchange numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class ExchangeNumbers
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double temp;
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }

            Console.WriteLine("{0} {1}", a, b);
        }
    }
}