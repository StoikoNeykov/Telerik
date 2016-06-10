namespace ExtensionMethodsDelegatesLambdaLINQ.Tests
{
    using System;
    using System.Text;
    using ExtensionMethodsDelegatesLambdaLINQ.Extensions;

    public static class StringbuilderTest
    {
        public static void Test()
        {
            var TestBuilder = new StringBuilder("This is simple test string. We hope my new extension method can split it.");
            var resultOfSplit = TestBuilder.Substring(0, 27);
            Console.WriteLine(resultOfSplit);

            resultOfSplit = TestBuilder.Substring(0, 0);
            Console.WriteLine(resultOfSplit);

            Console.WriteLine(TestBuilder.Length);

            resultOfSplit = TestBuilder.Substring(72);
            Console.WriteLine(resultOfSplit);

            resultOfSplit = TestBuilder.Substring(28);
            Console.WriteLine(resultOfSplit);
        }
    }
}
