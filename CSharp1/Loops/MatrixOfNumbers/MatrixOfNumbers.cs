namespace Loops
{
    /// <summary>
    /// Printing matrix of numbers
    /// </summary>
    using System;

    public class MatrixOfNumbers
    {
        public static void Main()
        {
            //chalenge accepted ! 
            int num = int.Parse(Console.ReadLine());
            int curentLine = 1;
            for (int i = 0; (i < num) && (curentLine < num + 1); i++)
            {
                Console.Write(curentLine + i);
                if (i != num - 1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine();
                    curentLine++;
                    i = -1;
                }
            }
        }
    }
}
