using System;
using System.Linq;
using System.Xml.Linq;

namespace NewAlbumsLinq
{
    public class Startup
    {
        static void Main()
        {
            var doc = XDocument.Load("../../../catalogue.xml");

            doc.Descendants("album")
                    .Where(x => int.Parse(x.Element("year").Value) > 1996)
                    .Select(x => x.Element("name").Value)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));
        }
    }
}
