using System;

using PrintManager.Contracts;

namespace PrintManager.Models
{
    // I dont see real reason to be nested class
    public class Printer
    {
        private ILogger logger;

        public Printer(ILogger logger = null)
        {
            if (logger != null)
            {
                this.logger = logger;
            }
        }

        public void BoolPrint(bool boolValue)
        {
            string boolAsString = boolValue.ToString();

            if (this.logger == null)
            {
                Console.WriteLine(boolAsString);
            }
            else
            {
                this.logger.WriteLine(boolAsString);
            }
        }
    }
}
