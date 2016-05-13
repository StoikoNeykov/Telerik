using System;

class TriangleSurfaceBySideAndAltitude
{
    static void Main()
    {
        double side = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:f2}",side*altitude/2);
    }
}

