namespace Loops
{
    /// <summary>
    /// Printing numbers (loops practice)
    /// </summary>
    using System;

    public class Numbers1toN
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i < num + 1; i++)
            {
                Console.Write("{0}", i);
                if (i < num)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}