namespace ConsoleInAndOut
{
    /// <summary>
    /// Program calculate sum 
    /// </summary> 
    using System;
    using System.Globalization;
    using System.Threading;

    public class SumOfN
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            byte n = byte.Parse(Console.ReadLine());
            double sum = 0;
            double num;
            for (int i = 0; i < n; i++)
            {
                num = double.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}