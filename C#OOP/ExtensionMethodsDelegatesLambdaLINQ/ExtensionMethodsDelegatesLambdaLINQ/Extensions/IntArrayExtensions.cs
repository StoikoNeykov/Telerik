namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System.Linq;

    /// <summary>
    /// Int Array extension
    /// </summary>
    public static class IntArrayExtensions
    {
        public static int[] DividebleByTwentyOne(this int[] numbers)
        {
            // I can make x = > x / 21 == 0; BUT its easier to change if need
            var result = numbers
                .Where(x => x % 7 == 0 && x % 3 == 0)
                .ToArray();
            return result;
        }
    }
}