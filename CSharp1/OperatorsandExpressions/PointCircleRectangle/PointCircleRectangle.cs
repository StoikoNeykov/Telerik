namespace OperatorsandExpressions
{
    /// <summary>
    /// Program reads a pair of coordinates x and y and uses an expression to checks for given point (x, y)
    /// if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
    /// </summary>
    using System;

    public class PointCircleRectangle
    {
        public static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double newX = x - 1;
            double newY = y - 1;
            double distance = Math.Sqrt(newX * newX + newY * newY);
            bool inC = distance <= 1.5 ? true : false;
            bool inR = (-1 <= y) && (y <= 1) && (-1 <= x) && (x <= 5) ? true : false;
            string c = inC ? "inside circle" : "outside circle";
            string r = inR ? "inside rectangle" : "outside rectangle";
            Console.WriteLine("{0} {1}", c, r);
        }
    }
}
