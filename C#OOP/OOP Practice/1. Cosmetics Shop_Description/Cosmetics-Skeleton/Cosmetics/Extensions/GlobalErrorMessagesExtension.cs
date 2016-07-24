namespace Cosmetics.Extensions
{
    /// <summary>
    /// Is not real extension - just wanna add that msg to original global errors but is not allowed
    /// </summary>
    public static class GlobalErrorMessagesExtension
    {
        public const string NegativeArgumentMessage = "{0} cannot be negative number!";
        public const string ZeroOrNegativeArgumentMessage = "{0} cannot be negative or zero!";
        public const string ZeroArgumentMessage = "{0} cannot be zero!";
        public const string ProductNotFound = "Product {0} does not exist in category {1}!";
    }
}
