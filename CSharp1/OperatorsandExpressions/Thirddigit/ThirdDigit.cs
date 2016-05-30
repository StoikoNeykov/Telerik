namespace OperatorsandExpressions
{
    /// <summary>
    /// Program check if digit on the position 3 is 7 (right to left and starts from 0).
    /// </summary>
    using System;

    public class ThirdDigit
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int thirdDigit = (num % 1000) / 100;
            Console.WriteLine((thirdDigit == 7) ? "true" : "false " + thirdDigit);
        }
    }
}
