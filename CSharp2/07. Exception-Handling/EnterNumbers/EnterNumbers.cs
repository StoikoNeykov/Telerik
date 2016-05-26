using System;

class EnterNumbers
{
    static void Main()
    {
        string result = string.Empty;
        try
        {
            result = ReadNumber();
            Console.WriteLine("1" + result + " < 100");
        }
        catch (Exception)
        {

            Console.WriteLine("Exception");
        }

    }

    static string ReadNumber()
    {
        int last = 1;
        string result = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num <= last)
            {
                throw new ArgumentException();
            }
            else
            {
                result += " < " + num.ToString();
                last = num;
            }
        }
        if (last < 100)
        {
            return result;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

