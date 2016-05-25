using System;
class CorrectBrackets
{
    static void Main()
    {
        string text = Console.ReadLine();
        int counter = 0;
        foreach (var symbol in text)
        {
            if (symbol == '(')
            {
                counter++;
            }
            else if (symbol == ')')
            {
                counter--;
                if (counter < 0)
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}

