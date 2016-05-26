using System;
using System.Linq;

class ExtractSentences
{
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string[] splitted = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        char[] separators = text.Where(c => !char.IsLetter(c))
                                 .Distinct()
                                 .ToArray();

        foreach (var sent in splitted)
        {
            string[] words = sent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (word == words[i].Trim())
                {
                    Console.Write(sent.Trim() + ". ");
                    break;
                }

            }

        }
    }
}