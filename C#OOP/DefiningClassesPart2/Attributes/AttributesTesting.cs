namespace Attributes
{
    using System;
    using System.Text;

    [Version(0, 56)]
    public class AttributesTesting
    {
        public static void Test()
        {
            Type type = typeof(AttributesTesting);
            Console.WriteLine("Class AttributesTesting");
            Console.WriteLine(ReturnVersionAtt(type));

            type = typeof(StartUp);
            Console.WriteLine("Class StartUp");
            Console.WriteLine(ReturnVersionAtt(type));

            type = typeof(VersionAttribute);
            Console.WriteLine("Class VersionAttribute");
            Console.WriteLine(ReturnVersionAtt(type));

            Console.WriteLine(CheckAttributeUsage(type));
        }

        // worst way to make it works !!!
        public static string ReturnVersionAtt(Type type)
        {
            string result = string.Empty;
            var attributes = type.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                try
                {
                    // Version do not allow miltiply -> only once will come here
                    result += (VersionAttribute)attribute;
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static string CheckAttributeUsage(Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            var output = new StringBuilder();
            foreach (var attribute in attributes)
            {
                try
                {
                    var result = (AttributeUsageAttribute)attribute;
                    output.AppendLine("AttributeUsage:");
                    output.AppendLine(string.Format("AllowMultiple: {0}", result.AllowMultiple));
                    output.Append(string.Format("Valid on: {0}", result.ValidOn));
                }
                catch (Exception)
                {
                }
            }
            return output.ToString();
        }
    }
}
