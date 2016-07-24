namespace Cosmetics.Extensions
{
    using System;
    using System.Collections.Generic;

    using Common;

    /// <summary>
    /// not real extension - just wanna add this methods to the class but is not allowed
    /// Methods can have more "abstract" names like CheckIfUintIsZero 
    /// </summary>
    public static class ValidatorExtension
    {
        /// <summary>
        /// Exception message: "${parametername} cannot be negative number!"
        /// </summary>
        public static void CheckIfDecimalIsNegative(decimal value, string parameterName)
        {
            if (parameterName == null)
            {
                parameterName = "Value";
            }

            if (value < 0)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessagesExtension.NegativeArgumentMessage, parameterName));
            }
        }

        /// <summary>
        /// Exception message: "${parametername} cannot be zero!"
        /// </summary>
        public static void CheckIfUintIsZero(uint value, string parameterName)
        {
            if (parameterName == null)
            {
                parameterName = "Value";
            }

            if (value == 0)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessagesExtension.ZeroArgumentMessage, parameterName));
            }
        }

        public static void CheckIfIngredientsAreValid(IEnumerable<string> ingredients)
        {
            var tooLongStringFormat = string.Format(GlobalErrorMessages.InvalidStringLength,
                                            "Ingredients",
                                            GlobalConstants.MinIntragentNameLength,
                                            GlobalConstants.MaxIntragentNameLength);

            var result = ingredients
                .ForEach(x => Validator.CheckIfStringIsNullOrEmpty(x, tooLongStringFormat))
                .ForEach(x => Validator.CheckIfStringLengthIsValid(x,
                                                                   GlobalConstants.MaxIntragentNameLength,
                                                                   GlobalConstants.MinIntragentNameLength,
                                                                   tooLongStringFormat));
        }
    }
}
