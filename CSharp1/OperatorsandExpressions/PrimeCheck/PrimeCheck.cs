namespace OperatorsandExpressions
{
    /// <summary>
    /// Prime check 
    /// </summary> 
    using System;

    public class PrimeCheck
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num <= 1)
            {
                Console.WriteLine("false");
            }
            else
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }

                Console.WriteLine("true");
            }
        }
    }
}
