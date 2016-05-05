using System;

class CompareCharArrays
{
    static void Main()
    {
        string text = Console.ReadLine();
        var arrOne = text.ToCharArray();
        text = null;
        text = Console.ReadLine();
        var arrTwo = text.ToCharArray();
        text = null;
        int size = arrTwo.Length;
        if (arrOne.Length == arrTwo.Length)
        {
            text = "=";
            for (int i = 0; i < size; i++)
            {
                if (arrOne[i] > arrTwo[i])
                {
                    text = ">";
                    break;
                }
                else if (arrOne[i] < arrTwo[i])
                {
                    text = "<";
                    break;
                }
            }
        }
        else if (arrOne.Length > arrTwo.Length)
        {
            text = ">";
        }
        else
        {
            text = "<";
            size = arrOne.Length;
        }
        
        Console.WriteLine(text);

    }
}

