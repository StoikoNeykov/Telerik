using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GetProductsInCategories
{
    public class Startup
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(@"Server=.\SQLEXPRESS;" +
                                                    "Database=NORTHWND;" +
                                                    "Integrated Security=true;");

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCategories = new SqlCommand(
                     "SELECT ProductName, CategoryName FROM Products AS p " +
                     "JOIN Categories AS c " +
                     "ON p.CategoryID = c.CategoryID", dbCon);

                var categories = new Dictionary<string, IList<string>>();
                SqlDataReader reader = cmdCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        if (categories.ContainsKey(categoryName))
                        {
                            categories[categoryName].Add(productName);
                        }
                        else
                        {
                            categories.Add(categoryName, new List<string>());
                            categories[categoryName].Add(productName);
                        }
                    }
                }

                foreach (var category in categories)
                {
                    Console.WriteLine("{0} - {1}", category.Key, string.Join(", ", category.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
