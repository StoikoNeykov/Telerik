using System;
using System.Data.SqlClient;

namespace GetCountOfCategoryRows
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
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);

                var categoryCount = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Category count is: {categoryCount}");
            }
        }
    }
}
