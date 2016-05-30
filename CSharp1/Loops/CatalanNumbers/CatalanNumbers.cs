namespace Loops
{
    /// <summary>
    /// Calculating catalan numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Numerics;
    using System.Threading;

    public class CatalanNumbers
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int num = int.Parse(Console.ReadLine());
            BigInteger facOut = 1;
            BigInteger facIn = 1;
            for (int i = num + 1; i <= 2 * num; i++)
            {
                facOut *= i;
            }

            for (int i = 1; i <= num + 1; i++)
            {
                facIn *= i;
            }

            Console.WriteLine(facOut / facIn);
        }
    }
}