namespace OperatorsandExpressions
{
    /// <summary>
    /// Program exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer(read from the console).
    /// </summary>
    using System;

    public class BitExchange
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            long mask1 = 56L;
            long mask2 = 117440512L;
            long result1 = num & mask1;
            long result2 = num & mask2;
            num = num & ~117440568;
            num = num | (result1 << 21) | (result2 >> 21);
            Console.WriteLine(num);
        }
    }
}
