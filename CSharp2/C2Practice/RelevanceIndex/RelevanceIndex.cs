using System;
using System.Collections.Generic;

class RelevanceIndex
{
    static void Main()
    {
        string[] separators = new string[] { " ", ",", ".", "(", ")", ";", "-", "!", "?" };

        var texts = new List<string>();
        var counts = new List<int>();

        var patern = Console.ReadLine().ToLower().Trim();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            int counter = 0;
            var curentLine = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < curentLine.Length; j++)
            {
                if (curentLine[j].ToLower() == patern)
                {
                    curentLine[j] = curentLine[j].ToUpper();
                    counter++;
                }
            }
            texts.Add(string.Join(" ", curentLine));
            counts.Add(counter);
        }

        while (true)
        {
            int max = -1;
            int maxIndex = -1;
            for (int i = 0; i < counts.Count; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    maxIndex = i;
                }
            }
            if (maxIndex==-1)
            {
                break;
            }
            Console.WriteLine(texts[maxIndex]);
            counts[maxIndex] = -1;
            
        }

    }
}
