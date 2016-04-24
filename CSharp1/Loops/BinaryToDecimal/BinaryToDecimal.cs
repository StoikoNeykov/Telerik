using System;

class BinaryToDecimal
{
    static void Main()
    {
        string text = Console.ReadLine();
        char[] arr = text.ToCharArray();
        int theNum = 0;
        int pow = 1;
        int i = 0;
        do
        {
            int curent = arr[arr.Length - i - 1] - '0';
            theNum += curent * pow;
            i++;
            pow *= 2;
        } while (i < arr.Length);
        Console.WriteLine(theNum);
    }
}
