using System;
using System.Linq;

namespace ExchangeRates
{
    public class Program
    {
        public static void Main()
        {
            double c1 = double.Parse(Console.ReadLine());
            double c2 = 0f;

            double max1 = c1;
            double max2 = c2;

            double newMax1 = 0;
            double newMax2 = 0;

            int days = int.Parse(Console.ReadLine());

            for (int i = 0; i < days; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
                var first = input[0];
                var second = input[1];

                newMax2 = max1 * first;

                newMax1 = max2 * second;


                if (newMax1 > max1)
                {
                    max1 = newMax1;
                }

                if (newMax2 > max2)
                {
                    max2 = newMax2;
                }

            }

            Console.WriteLine("{0:0.00}", max1);
        }
    }
}
