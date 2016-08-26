// other way to refactor the code
using System;

namespace PrintManager
{
    public static class StartUp
    {
        public static void Main()
        {
            PrintBool(true);
        }

        public static void PrintBool(bool boolToPrint)
        {
            string boolAsString = boolToPrint.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}
