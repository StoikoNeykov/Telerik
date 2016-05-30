namespace ConsoleInAndOut
{
    /// <summary>
    /// Program print circle`s ara and perimeter by given radius
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class Circle
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2} {1:f2}", 2 * Math.PI * r, Math.PI * r * r);
        }
    }
}