namespace Loops
{
    /// <summary>
    /// Print numbers not dividible by 3 and 7 without 
    /// </summary>
    using System;

    public class NotDivisibleNumbers
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 || i % 7 == 0)
                {
                    continue;
                }

                Console.Write("{0}", i);
                if (i != num)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}