using NorthWind;
using System;
using System.Linq;

namespace EntityConcurrency
{
    public class Startup
    {
        static void Main(string[] args)
        {
            // task - 7 - https://msdn.microsoft.com/en-us/data/jj592904.aspx
            for (int i = 0; i < 5; i++)
            {
                var firstConection = new NWEntities();
                var secondConection = new NWEntities();

                Console.WriteLine($"Now i = {i}");
                // Original company name "Alfreds Futterkiste"
                var firstCustomer = firstConection.Customers
                                                .Where(x => x.ContactName == "Maria Anders")
                                                .FirstOrDefault();
                var secondCustomer = secondConection.Customers
                                                .Where(x => x.ContactName == "Maria Anders")
                                                .FirstOrDefault();

                Console.WriteLine("Name from first connection: " + firstCustomer.CompanyName);
                Console.WriteLine("Name from second connection: " + secondCustomer.CompanyName);

                firstCustomer.CompanyName = "Tlerik 1";
                secondCustomer.CompanyName = "Telerik 2";

                secondConection.SaveChanges();
                firstConection.SaveChanges();

                var result = new NWEntities()
                                    .Customers.Where(x => x.ContactName == "Maria Anders")
                                    .FirstOrDefault();
                Console.WriteLine("Final company name {0}", result.CompanyName);
                Console.WriteLine();
            }
        }
    }
}
