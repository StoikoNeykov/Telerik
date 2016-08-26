using System;

using PrintManager.Models;

namespace PrintManager
{
    public class StartUp
    {
        // constant was deleted coz never used! 
        public static void Main()
        {
            var printer = new Printer();
            printer.BoolPrint(true);
        }
    }
}
