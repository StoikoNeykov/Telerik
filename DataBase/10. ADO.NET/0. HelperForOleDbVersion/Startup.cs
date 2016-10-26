using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace HelperForOleDbVersion
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = OleDbEnumerator.GetRootEnumerator();

            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine("{0} = {1}", reader.GetName(i), reader.GetValue(i));
                }

                Console.WriteLine();
            }
            reader.Close();
        }
    }
}
