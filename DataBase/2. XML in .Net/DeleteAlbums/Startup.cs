using System.IO;
using System;
using System.Xml;

namespace DeleteAlbums
{
    public class Startup
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            var root = doc.DocumentElement;

            DeleteAlbumsWithPrice(root, 20.0);
            doc.Save("../../updatedCatalogue.xml");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("new catalogue saved as " + savedDir + "updatedCatalogue.xml");
        }

        private static void DeleteAlbumsWithPrice(XmlElement root, double maxPrice)
        {
            var childNodes = root.ChildNodes;

            for (int i = childNodes.Count - 1; i >= 0; i--)
            {
                var album = childNodes[i];

                var xmlPrice = album["price"].InnerText;
                var price = double.Parse(xmlPrice);

                if (price > maxPrice)
                {
                    root.RemoveChild(album);
                }
            }
        }
    }
}
