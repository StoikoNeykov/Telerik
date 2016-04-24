using System;

class BitsToBits
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string text = null;
        for (int i = 0; i < num; i++)
        {
            int curent = int.Parse(Console.ReadLine());
            string curentString = Convert.ToString(curent, 2).PadLeft(30, '0');
            text += curentString;
        }
        char lastSymbol = '2';
        int counter0 = 0;
        int counter1 = 0;
        int counter0max = 0;
        int counter1max = 0;
        foreach (char symbol in text)
        {
            if (symbol == '0')
            {
                if (lastSymbol == '0')
                {
                    counter0++;
                    if (counter0 > counter0max)
                    {
                        counter0max = counter0;
                    }
                }
                else
                {
                    lastSymbol = '0';
                    counter0 = 1;
                    if (counter0 > counter0max)
                    {
                        counter0max = counter0;
                    }
                }
            }
            else //symbol='1'
            {
                if (lastSymbol == '1')
                {
                    counter1++;
                    if (counter1max < counter1)
                    {
                        counter1max = counter1;
                    }
                }
                else
                {
                    lastSymbol = '1';
                    counter1 = 1;
                    if (counter1max < counter1)
                    {
                        counter1max = counter1;
                    }
                }
            }


        }
        Console.WriteLine(counter0max);
        Console.WriteLine(counter1max);
    }
}


