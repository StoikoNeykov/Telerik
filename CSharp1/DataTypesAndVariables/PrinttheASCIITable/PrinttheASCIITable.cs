namespace DataTypesAndVariables
{
    /// <summary>
    /// Program print on console ASCII characters from 33 to 126 including
    /// </summary>
    using System;

    public class PrinttheASCIITable
    {
        public static void Main(string[] args)
        {
            for (int i = 33; i <= 126; i++)
            {
                Console.Write((char)i);
            }
        }
    }
}