using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        var que = new Queue<char>();
        for (int i = 0; i < lines; i++)
        {
            string text = Console.ReadLine();
            var arr = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            char digitOne;
            char digitTwo;
            if (arr[2] == "before")
            {
                digitOne = text[0];
                digitTwo = text[text.Length - 1];
            }
            else
            {
                digitTwo = text[0];
                digitOne = text[text.Length - 1];
            }
            if (digitOne == '0')
            {
                que.Enqueue(digitOne);
                que.Enqueue(digitTwo);
            }
            else
            {
                Positioner(builder, digitOne, digitTwo);
            }
        }
        while (que.Count > 0)
        {
            char digitOne = que.Dequeue();
            char digitTwo = que.Dequeue();
            Positioner(builder, digitOne, digitTwo);
        }
        if (builder[0] == '0' && builder.Length > 1)
        {
            builder.Remove(0, 1);
        }
        Console.WriteLine(builder.ToString());
    }
    static void Positioner(StringBuilder builder, char digitOne, char digitTwo)
    {
        if (builder.Length == 0)
        {
            builder.Append(digitOne);
            builder.Append(digitTwo);
        }
        else
        {
            int index = 0;
            if (digitOne == '0')
            {
                index = ZeroPointer(builder, 0);
            }
            else
            {
                index = Pointer(builder, index, digitOne);
            }
            if (index == builder.Length)
            {
                builder.Append(digitTwo);
            }
            else if (digitTwo == '0')
            {
                index = ZeroPointer(builder, index);
            }
            else
            {
                index = Pointer(builder, index, digitTwo);
            }
        }
    }
    static int Pointer(StringBuilder builder, int index, char digit)
    {
        if (digit == '0' && index == 0)
        {
            index++;
        }
        for (int i = index; i < builder.Length; i++)
        {
            if (builder[i] == digit)
            {
                index = i + 1;
                break;
            }
            else if (builder[i] > digit)
            {
                builder.Insert(i, digit);
                index = i + 1;
                break;
            }
            else if (builder[i] < digit && i == builder.Length - 1)
            {
                builder.Append(digit);
                index = builder.Length;
                break;
            }
        }
        return index;
    }
    static int ZeroPointer(StringBuilder builder, int index)
    {
        for (int i = index; i < builder.Length; i++)
        {
            if (builder[i] == '0')
            {
                return i + 1;
            }
        }
        index = Pointer(builder, index, '0');
        return index;
    }
}
