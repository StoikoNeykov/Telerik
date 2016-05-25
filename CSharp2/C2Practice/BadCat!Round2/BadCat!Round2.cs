using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var builder = new StringBuilder();
        var depends = new int[10, 10];

        //depends[rows,cols] where row before col 

        for (int i = 0; i < lines; i++)
        {
            string text = Console.ReadLine();
            var arr = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int number1 = 0;
            int number2 = 0;

            if (arr[2] == "before")
            {
                number1 = int.Parse(arr[0]);
                number2 = int.Parse(arr[3]);
            }
            else
            {
                number2 = int.Parse(arr[0]);
                number1 = int.Parse(arr[3]);
            }
            depends[number1, number2] = 1;
        }
    }

}

