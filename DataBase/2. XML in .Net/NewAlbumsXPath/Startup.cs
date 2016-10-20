using System;
using System.Xml;

namespace NewAlbumsXPath
{
    public class Startup
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var query = "/catalogue/album[year>1996]/name";

            var albumNames = doc.SelectNodes(query);

            foreach (XmlNode name in albumNames)
            {
                Console.WriteLine(name.InnerText);
            }
        }
    }
}
