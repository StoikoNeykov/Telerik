namespace ConditionalStatements
{
    /// <summary>
    /// Program "finding" product sign without calc (if-else practice)
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class MultiplicationSign
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine("0");
            }
            else if ((a > 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c < 0) ||
                (a < 0 && b > 0 && c < 0) || (a < 0 && b < 0 && c > 0))
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }
}