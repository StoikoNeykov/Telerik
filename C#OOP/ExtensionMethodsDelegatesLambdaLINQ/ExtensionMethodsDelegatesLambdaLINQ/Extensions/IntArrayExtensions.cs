namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System.Linq;

    public static class IntArrayExtensions
    {
        public static int[] DividebleByTwentyOne(this int[] numbers)
        {
            // I can make x = > x / 21 == 0; BUT if it mean by 7 OR by 3 can change it to || after ! 
            var result = numbers
                .Where(x => x % 7 == 0 && x % 3 == 0)
                .ToArray();
            return result;
        }
    }
}