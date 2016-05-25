using System;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string text = Console.ReadLine();
        var builder = new StringBuilder();
        builder.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != builder[builder.Length - 1])
            {
                builder.Append(text[i]);
            }
        }
        text = builder.ToString();
        Console.WriteLine(text);
    }
}

