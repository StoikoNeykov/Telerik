using System;

class TextToNumber
{
    static void Main()
    {
        short num = short.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        int curent, result = 0;
        for (int i = 0; i < str.Length; i++)
        {
            curent = (int)str[i];
            if (curent == 64)
            {
                Console.WriteLine(result);
            }
            else if (curent < 48 || (57 < curent && curent < 64) || (90 < curent && curent < 97) || curent > 122)
            {
                result %= num;
            }
            else if (48 <= curent && curent <= 57)
            {
                result *= (curent - 48);
            }
            else if (64 <= curent && curent <= 90)
            {
                result += (curent - 65);
            }
            else
            {
                result += (curent - 97);
            }
        }
    }
}
