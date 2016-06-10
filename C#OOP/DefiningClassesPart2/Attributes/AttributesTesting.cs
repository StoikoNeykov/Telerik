namespace Attributes
{
    using System;
    using System.Text;

    /// <summary>
    /// Class that testing other classes 
    /// </summary>
    [Version(0, 56)]
    public class AttributesTesting
    {
        public static void Test()
        {
            Type type = typeof(AttributesTesting);
            Console.WriteLine("Class AttributesTesting");
            Console.WriteLine(AttributesCheck(type));

            type = typeof(StartUp);
            Console.WriteLine("Class StartUp");
            Console.WriteLine(AttributesCheck(type));

            type = typeof(VersionAttribute);
            Console.WriteLine("Class VersionAttribute");
            Console.WriteLine(AttributesCheck(type));
        }

        // take type, separate attributes and call methods that return info about
        public static string AttributesCheck(Type type)
        {
            var output = new StringBuilder();
            var attributes = type.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                if (attribute is VersionAttribute)
                {
                    VersionAttribute curentAttribute = attribute as VersionAttribute;
                    output.AppendLine(VersionAttAsString(curentAttribute));
                }
                else if (attribute is AttributeUsageAttribute)
                {
                    AttributeUsageAttribute curentAttribute = attribute as AttributeUsageAttribute;
                    output.AppendLine(AttUsageAttAsString(curentAttribute));
                }

            }
            return output.ToString();
        }

        // return info for AttributeUsageAttribute
        private static string AttUsageAttAsString(AttributeUsageAttribute curentAttribute)
        {
            var output = new StringBuilder();
            output.AppendLine("AttributeUsage:");
            output.AppendLine(string.Format("AllowMultiple: {0}", curentAttribute.AllowMultiple));
            output.Append(string.Format("Valid on: {0}", curentAttribute.ValidOn));
            return output.ToString();
        }

        // return information for VersionAttribute
        private static string VersionAttAsString(VersionAttribute curentAttribute)
        {
            return curentAttribute.ToString();
        }
    }
}
