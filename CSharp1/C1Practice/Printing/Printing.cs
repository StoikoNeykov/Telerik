using System;



class Printing
{
    static void Main()
    {
        short stud = short.Parse(Console.ReadLine());
        short paper = short.Parse(Console.ReadLine());
        float price = float.Parse(Console.ReadLine());
        float saved = (stud * paper * price) / 500;
        Console.WriteLine("{0:F2}", Math.Round(saved, 2));
    }
}

