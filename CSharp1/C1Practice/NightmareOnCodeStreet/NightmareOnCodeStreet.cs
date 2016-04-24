using System;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string text = Console.ReadLine();
        int sum = 0;
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if ((i % 2 == 1) && (text[i] - '0' >= 0) && (text[i] - '0' < 10))
            {
                sum += text[i] - '0';
                count++;
            }
        }
        Console.WriteLine("{0} {1}", count, sum);
    }
}

