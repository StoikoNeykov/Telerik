namespace OperatorsandExpressions
{
    /// <summary>
    /// Program first reads 4 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} with 
    /// bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console.
    /// </summary>
    using System;

    public class BitSwap
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long mask, pBit, qBit;
            for (int i = 0; i < k; i++)
            {
                mask = 1L << (p + i);
                pBit = (num & mask) >> (p + i);
                mask = 1L << (q + i);
                qBit = (num & mask) >> (q + i);
                if (pBit != qBit)
                {
                    mask = (1L << (p + i)) | (1L << (q + i));
                    num = num ^ mask;
                }
            }

            Console.WriteLine(num);
        }
    }
}
