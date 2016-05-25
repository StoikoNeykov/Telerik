using System;

class SubStringInText
{
    static void Main()
    {
        string patern = Console.ReadLine();
        string text = Console.ReadLine();
        int counter = 0;

        for (int i = 0; i < text.Length - patern.Length + 1; i++)
        {
            if (text.Substring(i, patern.Length).Equals(patern, StringComparison.OrdinalIgnoreCase))
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}

