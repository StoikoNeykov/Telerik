using System;
using System.Text.RegularExpressions;

class ReplaceTags
{
    static void Main()
    {

        string text = Console.ReadLine();
        string patern = @"<a href=""(.*)"">(.*)";
        string replace = @"[URL=…](…/URL)";
        var arr = text.Split(new[] { "</a>" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Regex.Replace(arr[i], patern, m => "[url=" + m.Groups[1].Value + "]" + m.Groups[2].Value + "[/url]");
        }
        text = string.Join("", arr);
        Console.WriteLine(text);


    }
}
