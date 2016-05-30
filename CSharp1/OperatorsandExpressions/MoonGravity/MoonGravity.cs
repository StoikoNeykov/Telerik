namespace OperatorsandExpressions
{
    /// <summary>
    /// Program calculate weight on the moon
    /// </summary>
    using System;

    public class MoonGravity
    {
        public static void Main()
        {
            double weight = double.Parse(Console.ReadLine());
            double onTheMoon = 0.17 * weight;
            Console.WriteLine("{0:F3}", onTheMoon);
        }
    }
}