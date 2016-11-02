using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using System;
using System.Data.Entity;
using System.Linq;

namespace StudentSystem.Client
{
    public class Startup
    {
        public static void Main()
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            var con = new StudentSystemContext();

            Console.WriteLine("Students currently in the system: ");
            con.Students
                .Select(s => new { s.FirstName, s.LastName })
                .ToList()
                .ForEach(s => Console.WriteLine("- {0} {1}", s.FirstName, s.LastName));
        }
    }
}
