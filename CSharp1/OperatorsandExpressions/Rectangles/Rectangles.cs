namespace OperatorsandExpressions
{
    /// <summary>
    /// Calculate rectangle's area and perimeter
    /// </summary>
    using System;

    public class Rectangles
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2} {1:F2}", width * height, 2 * (width + height));
        }
    }
}
