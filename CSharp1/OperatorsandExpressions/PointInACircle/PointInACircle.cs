namespace OperatorsandExpressions
{
    /// <summary>
    /// Program reads the coordinates of a point x and y and using an expression checks if given point (x, y)
    /// is inside a circle K({0, 0}, 2) - the center has coordinates (0, 0) and the circle has radius 2.
    /// </summary>
    using System;

    public class PointInACircle
    {
        public static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double distance = Math.Round(Math.Sqrt((x * x) + (y * y)), 2);
            bool isIn = distance <= 2 ? true : false;
            if (isIn)
            {
                Console.WriteLine("yes {0:F2}", distance);
            }
            else
            {
                Console.WriteLine("no {0:F2}", distance);
            }
        }
    }
}
