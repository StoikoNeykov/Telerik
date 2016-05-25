using System;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        string patern = Console.ReadLine();
        patern = " " + patern + " ";
        string text = Console.ReadLine();
        var builder = new StringBuilder();
        var arr = text.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arr.Length; i++)
        {
            var temp = arr[i].ToCharArray();
            for (int j = 0; j < temp.Length; j++)
            {

                if (!Char.IsLetter(temp[j]))
                {
                    temp[j] = ' ';
                }
            }
            string a = " " + new String(temp) + " ";
            if (a.IndexOf(patern, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (builder.Length != 0)
                {
                    builder.Append(".");
                }
                builder.Append(arr[i]);
            }
        }
        if (builder.Length != 0)
        {
            builder.Append(".");
        }
        Console.WriteLine(builder.ToString());
    }
}

