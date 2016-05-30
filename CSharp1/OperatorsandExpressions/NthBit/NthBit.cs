namespace OperatorsandExpressions
{
    /// <summary>
    /// Program finds specific bit in long number
    /// </summary>
    using System;

    public class NthBit
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long mask = 1 << n;
            long theBit = (num & mask) >> n;
            Console.WriteLine(theBit);
        }
    }
}
