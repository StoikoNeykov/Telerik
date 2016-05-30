namespace OperatorsandExpressions
{
    /// <summary>
    /// Program print "true" if number can be divided by 5 and 7 without reminder.
    /// </summary>
    using System;

    public class DivideBy7And5
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isTrue = (num % 5 == 0) && (num % 7 == 0) ? true : false;
            Console.WriteLine(isTrue ? "true " + num : "false " + num);
        }
    }
}