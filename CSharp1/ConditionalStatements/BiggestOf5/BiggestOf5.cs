namespace ConditionalStatements
{
    /// <summary>
    /// Program finding biggest number
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class BiggestOf5
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            if (a < b)
            {
                a = b;
            }

            if (a < c)
            {
                a = c;
            }

            if (a < d)
            {
                a = d;
            }

            if (a < e)
            {
                a = e;
            }
            Console.WriteLine(a);
        }
    }
}