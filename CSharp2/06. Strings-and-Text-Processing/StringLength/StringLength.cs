using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        text=text.Replace(@"\", String.Empty);
        Console.WriteLine(text.PadRight(20, '*'));
    }
}
