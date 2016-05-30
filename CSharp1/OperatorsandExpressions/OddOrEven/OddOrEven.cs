namespace OperatorsandExpressions
{
    /// <summary>
    /// Odd/Even check with bitwise operations
    /// </summary>
    using System;

    public class OddOrEven
    {
        public static void Main()
        {
            sbyte num = sbyte.Parse(Console.ReadLine());
            sbyte mask = 1;
            bool isOdd = (num & mask) == 1 ? true : false;
            Console.WriteLine(isOdd ? "odd " + num : "even " + num);
        }
    }
}
