﻿using System;
using System.IO;
using System.Xml.Linq;

namespace TraverseDirectoryXDocument
{
    public class Startup
    {
        public static void Main()
        {
            var desktop = Traverse(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            desktop.Save("../../dir.xml");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        static XElement Traverse(string dir)
        {
            var element = new XElement("dir", new XAttribute("path", dir));

            foreach (var directory in Directory.GetDirectories(dir))
            {
                element.Add(Traverse(directory));
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                element.Add(new XElement("file", 
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)), 
                    new XAttribute("ext", Path.GetExtension(file))));
            }

            return element;
        }
    }
}
