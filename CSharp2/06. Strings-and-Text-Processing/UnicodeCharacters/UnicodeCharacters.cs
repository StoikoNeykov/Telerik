using System;
using System.Collections.Generic;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        var dict = new Dictionary<int, int>()
        {   { 97 , 7 },
            { 98 , 8 },
            { 102 , 12 },
            { 114 , 15 },
            { 116 , 9 },
            { 118 , 11 },
            { 39, 39 },
            { 34, 34 },
            { 92, 92 },
            { 63, 63 }
        };
        int key = Console.Read();
        bool special = false;
        while (key != 10 && key != 13)
        {
            if (key == 92)
            {
                special = true;
            }
            else if (special)
            {
                if (dict.ContainsKey(key))
                {
                    Console.Write("\\u{0:X4}", dict[key]);
                    special = false;
                }
                else
                {
                    Console.Write("\\u{0:X4}", 92);
                    Console.Write("\\u{0:X4}", key);
                    special = false;
                }

            }
            else
            {
                Console.Write("\\u{0:X4}", key);
            }
            key = Console.Read();
        }
        Console.WriteLine();

    }
}



//Encoding enc = Encoding.Unicode;
//string text = Console.ReadLine();
//var bytes = enc.GetBytes(text);
//for (int i = 0; i < bytes.Length; i++)
//{
//    if (bytes[i]==0)
//    {
//        continue;
//    }
//    Console.Write("\\u{0}",bytes[i].ToString("X4"));
//
//}
//Console.WriteLine();