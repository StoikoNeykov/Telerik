using System;
using System.Xml;

namespace AllSongsXmlReader
{
    public class Startup
    {
        static void Main()
        {
            using (XmlReader reader = new XmlTextReader("../../../catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
