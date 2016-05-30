namespace ConsoleInAndOut
{
    /// <summary>
    /// Program compare 2 numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class NumberComparer
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double numA = double.Parse(Console.ReadLine());
            double numB = double.Parse(Console.ReadLine());
            Console.WriteLine("{0}", numA > numB ? numA : numB);
        }
    }
}