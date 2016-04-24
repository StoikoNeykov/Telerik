using System;

class OddAndEvenProduct
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[] separator = { ' ' }; //only expected separator 
        string[] numbers = text.Split(separator);
        double pOdd = 1;
        double pEven = 1;
        for (int i = 0; i < num; i++)
        {
            if (i % 2 == 0)
            {
                pOdd *= double.Parse(numbers[i]);
            }
            else
            {
                pEven *= double.Parse(numbers[i]);
            }
        }
        if (pEven == pOdd)
        {
            Console.WriteLine("yes {0}", pOdd);
        }
        else
        {
            Console.WriteLine("no {0} {1}", pOdd, pEven);
        }
    }
}