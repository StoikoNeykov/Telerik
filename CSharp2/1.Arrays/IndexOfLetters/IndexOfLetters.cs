using System;

class IndexOfLetters
{
    static void Main()
    {
        var arr = new char[26];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] =(char)('a' + i) ;
        }
        string text = Console.ReadLine();
        for (int i = 0; i < text.Length; i++)
        {
            Console.WriteLine(Array.IndexOf(arr, text[i]));
        }
    }
}

