using MySql.Data.MySqlClient;
using System;

namespace MySqlLibrary
{
    class Startup
    {
        public static void Main()
        {
            /* Please first create the library by running
               "create-library.sql" in MySQL WorkBench */

            Console.Write("Enter MySQL password: ");
            string pass = Console.ReadLine();

            CreateDB("library", pass);

            string connectionStr = "Server=localhost;Database=library;Uid=root;Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);

            ListAllBooks(connection);
            Console.WriteLine();
            FindBookById(2, connection);
            Console.WriteLine();
            AddBook("Nemo", "Mark Twain", "222-222-222-22", connection);
            AddBook("Harry Potter 2", "J. K. Rolling", "111-111-111-11", connection);
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select b.Name as Book, a.Name as Author from books as b " +
                                                        "join authors as a " +
                                                        "on a.Id = b.AuthorId", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Books currently in library: ");
                Console.WriteLine();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("- {0} -\t by {1}", reader["Book"], reader["Author"]));
                    }
                }
            }
        }

        private static void FindBookById(int id, MySqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select b.Name as Book, a.Name as Author from books as b " +
                                                        "join authors as a " +
                                                        "on a.Id = b.AuthorId " +
                                                        "where b.Id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("The book with id of " + id + " is: ");
                        Console.WriteLine(string.Format("- {0} -\t by {1}", reader["Book"], reader["Author"]));
                    }
                    else
                    {
                        Console.WriteLine("There is no book with id of " + id + " in the library.");
                    }
                }
            }
        }

        private static void AddBook(string name, string author, string isbn, MySqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                MySqlCommand checkAuthor = new MySqlCommand("select a.Id as Id from authors as a " +
                                                            "join books as b " +
                                                            "on a.Id = b.AuthorId " +
                                                            "where a.Name = @author", connection);
                checkAuthor.Parameters.AddWithValue("@author", author);
                var reader = checkAuthor.ExecuteReader();

                int authorId;
                if (reader.Read())
                {
                    authorId = (int)reader["Id"];
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    MySqlCommand createAuthor = new MySqlCommand("insert into authors(Name) " +
                                                                 "values (@author)", connection);
                    createAuthor.Parameters.AddWithValue("@author", author);
                    createAuthor.ExecuteNonQuery();

                    Console.WriteLine("Author " + author + " added successfully!");

                    var cmdSelectIdentity = new MySqlCommand("select @@Identity", connection);
                    authorId = int.Parse(cmdSelectIdentity.ExecuteScalar().ToString());
                }

                MySqlCommand command = new MySqlCommand("insert into books(Name, AuthorId, ISBN) " +
                                                        "values (@name, @authorId, @isbn)", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@authorId", authorId);
                command.Parameters.AddWithValue("@isbn", isbn);
                command.ExecuteNonQuery();

                Console.WriteLine("Book " + name + " added successfully!");
            }
        }

        private static void CreateDB(string name, string pass)
        {
            string connectionStr = "Server=localhost;Uid=root;Pwd=" + pass + ";";
            MySqlConnection con = new MySqlConnection(connectionStr);

            string magicString = @"CREATE DATABASE  IF NOT EXISTS `library`;
USE `library`;

DROP TABLE IF EXISTS `authors`;

CREATE TABLE `authors` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

LOCK TABLES `authors` WRITE;
INSERT INTO `authors` VALUES (1,'J. K. Rolling'),(2,'John Steinbeck');
UNLOCK TABLES;

DROP TABLE IF EXISTS `books`;

CREATE TABLE `books` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `AuthorId` int(11) NOT NULL,
  `ISBN` varchar(20) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `ISBN_UNIQUE` (`ISBN`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


LOCK TABLES `books` WRITE;
INSERT INTO `books` VALUES (1,'Harry Potter',1,'1234-5678-123-9'),(2,'Of Mice and Man',2,'9876-2414-1111-0');
UNLOCK TABLES;";

            con.Open();
            using (con)
            {
                MySqlCommand createCommand = new MySqlCommand(magicString, con);

                createCommand.ExecuteScalar();
            }
        }
    }
}
