namespace OperatorsandExpressions
{
    /// <summary>
    /// Program modify specific bit in ulong value
    /// </summary>
    using System;

    public class ModifyBit
    {
        public static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            ulong value = ulong.Parse(Console.ReadLine());
            ulong mask = 1UL << position;
            ulong bit = (num & mask) >> position;
            if (value != bit)
            {
                num = num ^ mask;
            }

            Console.WriteLine(num);
        }
    }
}
