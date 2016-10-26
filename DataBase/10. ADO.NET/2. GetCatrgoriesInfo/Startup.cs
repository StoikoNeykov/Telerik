using System;
using System.Data.SqlClient;

namespace GetCatrgoriesInfo
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
                     "SELECT CategoryID, CategoryName, Description FROM Categories", dbCon);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int categoryId = (int)reader["CategoryID"];
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine($"{categoryId}. {categoryName}: {description}");
                }
            }
        }
    }
}
