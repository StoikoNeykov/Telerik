using System;

class TriangleSurfaceByThreeSides
{
    static void Main()
    {
        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double sideC = double.Parse(Console.ReadLine());
        double halfP = (sideA + sideB + sideC)/2;
        double surface = Math.Sqrt(halfP * (halfP - sideA) * (halfP - sideB) * (halfP - sideC));
        Console.WriteLine("{0:f2}",surface);
    }
}

