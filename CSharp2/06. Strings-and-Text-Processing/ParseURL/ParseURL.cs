using System;
using System.Linq;

class ParseURL
{
    static void Main()
    {
        string text = Console.ReadLine();
        var arr = text.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
        if (arr[0].Contains(" "))
        {
            arr[0] = arr[0].Split(' ').Last();
        }
        string site;
        string resource=string.Empty;
        if (arr[1].Contains("/"))
        {
            site = arr[1].Remove(arr[1].IndexOf("/"));
            resource = arr[1].Remove(0,arr[1].IndexOf("/"));
            if (resource.Contains(" "))
            {
                resource = resource.Split(' ').First();
            }
        }
        else
        {
            site = arr[1].Split(' ').First();
        }
        Console.WriteLine("[protocol] = {0}", arr[0]);
        Console.WriteLine("[server] = {0}", site);
        if (resource!=string.Empty)
        {
            Console.WriteLine("[resource] = {0}", resource);
        }
        
    }
}

