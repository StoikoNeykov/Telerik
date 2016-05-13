using System;

class TriangleSurfaceByTwoSidesAndAnAngle
{
    static void Main()
    {
        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double angle = double.Parse(Console.ReadLine());
        double area = (sideA * sideB * Math.Sin(Math.PI*angle/180)) / 2;
        Console.WriteLine("{0:f2}",area);
    }
}

