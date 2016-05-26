using System;
using System.Linq;

class VariableLengthCoding
{
    static void Main()
    {
        //read and transform code 
        var code = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Select(x => Convert.ToString(x, 2).PadLeft(8,'0'))
            .ToArray();
        var binaryCodes = string.Join("", code)
            .Split(new[] { "0" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Length)
            .ToArray();

        //read dictionary

        int lines = int.Parse(Console.ReadLine());

        var translator = new char[lines+1];
        for (int i = 0; i < lines; i++)
        {
            var dictElement = Console.ReadLine();
            int index = int.Parse(dictElement.Substring(1));
            char letter = dictElement[0];
            translator[index] = letter;
            
            
        }

        //decoding
        foreach (var binary in binaryCodes)
        {
            Console.Write(translator[binary]);


        }
        Console.WriteLine();
    }
}

