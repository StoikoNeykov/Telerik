using System;

class MoonGravity
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        double onTheMoon = (0.17 * weight);
        Console.WriteLine("{0:F3}", onTheMoon);
    }
}