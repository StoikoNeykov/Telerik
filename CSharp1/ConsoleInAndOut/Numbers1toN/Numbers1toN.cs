namespace ConsoleInAndOut
{
    /// <summary>
    /// Printing numbers
    /// </summary>
    using System;
    
    public class Numbers1toN
    {
        public static void Main()
        {
            ushort n = ushort.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
