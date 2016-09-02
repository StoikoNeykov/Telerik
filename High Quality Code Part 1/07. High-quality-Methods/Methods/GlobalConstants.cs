namespace Methods
{
    public static class GlobalConstants
    {
        // Student min/max age can be part or Student class too but way easier to maintain code when all 
        // magic numbers and string are in 1 file.
        public const int MinmumStudentAge = 18;
        public const int MaximumStudentAge = 80;

        public const string IsNullOrEmptyError = "{0} cannot be null or empty!";
        public const string InvalidParameterError = "Invalid {0}";

        public const string CannotBeNegativeOrZeroError = "{0} cannot be negative or zero!";
        public const string IsNotDigitError = "Parameter is not a digit!";
    }
}
