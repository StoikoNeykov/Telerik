using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string text = Console.ReadLine();
        var builder = new StringBuilder(text.Length);
        foreach (var symbol in text)
        {
            builder.Insert(0, symbol);
        }
        Console.WriteLine(builder.ToString());
    }
}
