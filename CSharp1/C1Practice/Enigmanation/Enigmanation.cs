using System;

class Enigmanation
{
    static void Main()
    {
        string text = Console.ReadLine();
        decimal result = 0;
        decimal resultOut = 0;
        char operatorOut = '+';
        char lastOperator = '+';
        foreach (char symbol in text)
        {
            if (symbol == '-' || symbol == '+' || symbol == '*' || symbol == '%')
            {
                lastOperator = symbol;
            }
            if (char.IsDigit(symbol))
            {
                switch (lastOperator)
                {
                    case '+': result += (symbol - '0'); break;
                    case '-': result -= (symbol - '0'); break;
                    case '*': result *= (symbol - '0'); break;
                    case '%': result %= (symbol - '0'); break;
                }
            }
            if (symbol == '(')
            {
                resultOut = result;
                operatorOut = lastOperator;
                result = 0;
                lastOperator = '+';
            }
            if (symbol == ')')
            {
                switch (operatorOut)
                {
                    case '+': resultOut += (result); break;
                    case '-': resultOut -= (result); break;
                    case '*': resultOut *= (result); break;
                    case '%': resultOut %= (result); break;
                }
                result = resultOut;
            }
            if (symbol == '=')
            {
                Console.WriteLine("{0:f3}", result);
            }
        }
    }
}

