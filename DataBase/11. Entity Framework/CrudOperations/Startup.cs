using NorthWind;
using System;
using System.Linq;

namespace CrudOperations
{
    public class Startup
    {
        // 2-5 actually
        public static void Main()
        {
            var northwind = new NWEntities();

            CustomerModifier.AddCustomer("TELER", "Telerik", "Ivaylo Kenov", "Trainer",
                                        "Al. Malinov 33", "Sofia", "SC", "1712", "Bulgaria", "+3592881122", "+3592112233");

            CustomerModifier.ModifyCompanyName("TELER", "Telerik, A Progress Company");

            CustomerModifier.DeleteCustomer("TELER");
            northwind.SaveChanges();

            Console.WriteLine("Customers who shipped to Canada in 1997: ");
            FindCustomersByOrdersYearAndCountry(northwind, 1997, "Canada");
            FindCustomersByOrdersYearAndCountryWithNativeSql(northwind, 1997, "Canada");

            Console.WriteLine("Orders shipped to Sao Paulo region between 18 and 19 years ago.");
            FindSalesByRegionAndTimePeriod(northwind, "SP", DateTime.Now.AddYears(-19), DateTime.Now.AddYears(-18));
        }

        // task 3 - Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        private static void FindCustomersByOrdersYearAndCountry(NWEntities northwind, int year, string country)
        {
            northwind.Orders
                .Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country)
                .Select(ord => ord.Customer)
                .GroupBy(c => c.CompanyName)
                .ToList().ForEach(cust => Console.WriteLine("- " + cust.Key));
        }

        // task 4 - Implement previous by using native SQL query and executing it through the DbContext.
        private static void FindCustomersByOrdersYearAndCountryWithNativeSql(NWEntities northwind, int year, string country)
        {
            string query = "SELECT c.CompanyName FROM Customers AS c " +
                           "JOIN Orders AS o " +
                           "ON c.CustomerId = o.CustomerId " +
                           "WHERE Country = '{0}' " +
                           "AND YEAR(OrderDate) = {1}" +
                           "GROUP BY c.CompanyName ";

            object[] parameters = { country, year };

            var customers = northwind.Database.SqlQuery<string>(string.Format(query, parameters));

            foreach (var customer in customers)
            {
                Console.WriteLine("- " + customer);
            }
        }

        private static void FindSalesByRegionAndTimePeriod(
                                                        NWEntities northwind,
                                                        string region,
                                                        DateTime startDate,
                                                        DateTime endDate)
        {
            northwind.Orders
                .Where(o => o.ShipRegion == region &&
                        o.OrderDate >= startDate &&
                        o.OrderDate <= endDate)
                .Select(o => new { o.OrderID, o.ShipCity })
                .ToList()
                .ForEach(o => Console.WriteLine(string.Format("Order #{0} to {1}", o.OrderID, o.ShipCity)));
        }
    }
}
