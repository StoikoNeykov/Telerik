using System;
using System.Linq;

namespace NorthWind
{
    public class Startup
    {
        public static void Main()
        {
            var northwind = new NWEntities();

            using (northwind)
            {
                Console.WriteLine("All products in Northwind database: ");
                northwind.Products
                    .Select(p => p.ProductName)
                    .ToList()
                    .ForEach(p => Console.WriteLine("- " + p));
            }
        }
    }
}
