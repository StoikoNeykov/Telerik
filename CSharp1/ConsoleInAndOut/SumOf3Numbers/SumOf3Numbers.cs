namespace ConsoleInAndOut
{
    /// <summary>
    /// Program calculate sum of floating point numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class SumOf3Numbers
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            float sum = 0;
            for (int i = 0; i < 3; i++)
            {
                float num = float.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}