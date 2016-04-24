using System;

    class Rectangles
    {
        static void Main(string[] args)
        {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2} {1:F2}", width * height, 2 * (width+height));
        }
    }

