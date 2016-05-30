namespace ConsoleInAndOut
{
    /// <summary>
    /// Program sum numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class SumOfFive
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            long sum = 0;
            for (int i = 0; i < 5; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
