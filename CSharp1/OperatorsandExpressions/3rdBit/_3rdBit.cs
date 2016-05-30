namespace OperatorsandExpressions
{
    /// <sumary>
    /// Program find value of the 3rd bit 
    /// </sumary>
    using System;

    public class _3rdBit
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int mask = 1 << 3;
            int thirdBit = (num & mask) >> 3;
            Console.WriteLine(thirdBit);
        }
    }
}