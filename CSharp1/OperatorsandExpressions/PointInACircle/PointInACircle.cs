using System;

    class PointInACircle
    {
        static void Main()
        {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double distance = Math.Round(Math.Sqrt((x * x) + (y * y)),2);
        bool isIn = (distance <= 2 ? true : false);
        if (isIn)
        {
            Console.WriteLine("yes {0:F2}",distance);
        }
        else
        {
            Console.WriteLine("no {0:F2}", distance);
        }
    }
    }

