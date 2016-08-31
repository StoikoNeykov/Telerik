using System;

namespace RefactorLoop
{
    public class Refactoring
    {
        public void LoopHolder()
        {
            // helpers
            var magicNumberFoundInOriginalCode = 100;
            var values = new int[magicNumberFoundInOriginalCode];

            // this value should %10==0 to pass conditions - its magic number ofc
            var expectedValue = 50;
            // end of helpers

            bool isFound = false;

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);

                if (values[i] % 10 == 0 && values[i] == expectedValue)
                {
                    isFound = true;
                }
            }

            // more code here - actually not ral reason that lot of code to be here. 
            // If posible (depend of code) this code should be on top of the loop or below if

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
