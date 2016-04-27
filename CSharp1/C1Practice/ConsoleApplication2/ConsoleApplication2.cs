using System;
using System.Globalization;
using System.Threading;
using System.Numerics;

class ConsoleApplication2
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string input = Console.ReadLine();
        string toTen = null;
        BigInteger product = 1;
        int counter = 0;
        while (input != "END")
        {
            if ((counter % 2 == 0) && (input != "0"))
            {
                while (input != string.Empty)
                {
                    if ((input[input.Length - 1] != '0')&& (input[input.Length - 1] != '-'))
                    {
                        product *= (input[input.Length - 1] - '0');
                    }
                    input = input.Substring(0, input.Length - 1);
                }

            }
            if (counter == 9)
            {
                toTen = product.ToString();
                product = 1;
            }
            counter++;
            input = Console.ReadLine();
        }



        //output
        if (counter > 9)
        {
            Console.WriteLine(toTen);
            Console.WriteLine(product);

        }
        else
        {
            Console.WriteLine(product);
        }
    }
}

