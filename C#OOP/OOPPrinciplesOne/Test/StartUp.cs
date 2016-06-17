namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using School = School.Models;
    using Humans = Humans.Models;
    using Extensions;
    using AnimalHierarchy.Models;
    using AnimalHierarchy.Enumerations;

    /// <summary>
    /// Mainly testing classes and data generators
    /// </summary>
    public static class StartUp
    {
        public static void Main()
        {
            // TestSchool();

            // FormatingStudentNames();

            // FormatingWorkerNames();

            // FormatAnimalsNames();

            // TestHumans();

            // TestAnimals();

            // TestMultyAnimals();
        }

        private static void TestSchool()
        {
            var math = new School.Discipline("Math");
            Console.WriteLine("math.ToString(): " + math);

            var petrov = new School.Teacher("Petrov");
            Console.WriteLine("Petrov.ToString(): " + petrov);

            petrov.AddDiscipline(math);
            // petrov.AddDiscipline(math); <-exeption
            petrov.RemoveDiscipline(math);
            petrov.AddDiscipline(math);

            var pesho = new School.Student("Pesho");
            Console.WriteLine("Pesho.ToString(): " + pesho);
            var gosho = new School.Student("Gosho");
            pesho.Comment = "Pesho hates math for no reason!";
            Console.WriteLine("Pesho.Comment: " + pesho.Comment);

            var fiveB = new School.ClassOfStudents("FiveB");
            Console.WriteLine("FiveB.ToString(): " + fiveB.ToString());

            fiveB.AddStudent(pesho);
            fiveB.RemoveStudent(pesho);
            fiveB.AddStudent(pesho);
            fiveB.AddStudent(gosho);
            fiveB.AddTeacher(petrov);

            var sch = new School.School("2865th");
            Console.WriteLine("Sch.ToString(): " + sch);
            sch.AddClass(fiveB);
            sch.Comment = "The school";
            Console.WriteLine("Sch.Comment: " + sch.Comment);
        }

        private static void TestHumans()
        {
            var students = GetStudents();
            var workers = GetWorkers();

            var orderedStudents = students
                .OrderBy(x => x.Grade)
                .ForEach(x => Console.WriteLine(x));
            PrintLine();

            var orderedWorkers = workers
                .OrderByDescending(x => x.MoneyPerHour())
                .ForEach(x => Console.WriteLine(x));
            PrintLine();

            ICollection<Humans.Human> merged = new List<Humans.Human>();

            students.ForEach(x => merged.Add(x));
            workers.ForEach(x => merged.Add(x));

            merged
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.Lastname)
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.Lastname}"));
        }

        private static void TestAnimals()
        {
            Random rng = new Random();
            var doge = new Dog("Doge", 5, Gender.Male);

            // chance a dog to find a stick is about 80% :D
            Console.WriteLine(doge.FollowTheStick(rng.Next(10)));
            Console.WriteLine(doge.FollowTheStick(rng.Next(10)));
            Console.WriteLine(doge.FollowTheStick(rng.Next(10)));
            Console.WriteLine(doge.FollowTheStick(rng.Next(10)));
            Console.WriteLine(doge.Sound());

            var otherDoge = new Dog("OtherDoge", 0, Gender.Male);
            Console.WriteLine(otherDoge.FollowTheStick(rng.Next(10)));
            otherDoge.Sound();
            PrintLine();

            var froggy = new Frog("Froggy", 2, Gender.Female, "green");
            Console.WriteLine(froggy.Sound());
            Console.WriteLine(froggy.Talk());
            Console.WriteLine(froggy.Sound());
            PrintLine();

            var cat = new Cat("Stamat", 3, Gender.Male);
            Console.WriteLine(cat.Play(rng.Next(10)));

            var kitty = new Kitty("Kitty", 1);
            Console.WriteLine(kitty.Play(rng.Next(10)));
            kitty.IncreaseAge(1);

            var tomcat = new Tomcat("TomCat", 2);
            Console.WriteLine(tomcat.Play(rng.Next(10)));
            PrintLine();


        }

        private static void TestMultyAnimals()
        {
            var animals = new List<Animal>();
            AddCats(animals);
            AddDogs(animals);
            AddFrogs(animals);
            AddKitties(animals);
            AddTomcats(animals);

            PrintAverages(animals);
        }

        public static void PrintAverages(IEnumerable<Animal> animals)
        {
            Console.WriteLine("Cats:");
            Console.WriteLine("{0:f2}", animals.Avrg(x => x is Cat ? x : null));
            Console.WriteLine("Dogs:");
            Console.WriteLine("{0:f2}", animals.Avrg(x => x is Dog ? x : null));
            Console.WriteLine("Frogs:");
            Console.WriteLine("{0:f2}", animals.Avrg(x => x is Frog ? x : null));
            Console.WriteLine("Kitties:");
            Console.WriteLine("{0:f2}", animals.Avrg(x => x is Kitty ? x : null));
            Console.WriteLine("Tomcats:");
            Console.WriteLine("{0:f2}", animals.Avrg(x => x is Tomcat ? x : null));
        }

        public static void PrintLine() => Console.WriteLine("--------------------------");

        // data generators
        public static List<Humans.Student> GetStudents()
        {
            var result = new List<Humans.Student>();

            result.Add(new Humans.Student("Glady", "Suther", 5));
            result.Add(new Humans.Student("Melanie", "Buchholtz", 6));
            result.Add(new Humans.Student("Lang", "Halladay", 2));
            result.Add(new Humans.Student("Kay", "Landrith", 1));
            result.Add(new Humans.Student("Nicky", "Bomar", 3));
            result.Add(new Humans.Student("Ivy", "Siple", 2));
            result.Add(new Humans.Student("Aracely", "Landis", 7));
            result.Add(new Humans.Student("Ashely", "Johson", 2));
            result.Add(new Humans.Student("Celestina", "Brust", 4));
            result.Add(new Humans.Student("Rogelio", "Sloat", 5));

            return result;
        }

        public static List<Humans.Worker> GetWorkers()
        {
            var result = new List<Humans.Worker>();

            result.Add(new Humans.Worker("Tatyana", "Postma", 200, 40));
            result.Add(new Humans.Worker("Bryon", "Morman", 180, 38));
            result.Add(new Humans.Worker("Milissa", "Lant", 160, 36));
            result.Add(new Humans.Worker("Shay", "Staples", 175, 38));
            result.Add(new Humans.Worker("Jonie", "Erler", 210, 40));
            result.Add(new Humans.Worker("Alyssa", "Tena", 260, 40));
            result.Add(new Humans.Worker("Dawn", "Chacko", 220, 35));
            result.Add(new Humans.Worker("Yan", "Stmartin", 230, 42));
            result.Add(new Humans.Worker("Elvie", "Admire", 240, 42));
            result.Add(new Humans.Worker("Kasey", "Marker", 200, 40));

            return result;
        }

        public static void AddCats(List<Animal> animals)
        {
            animals.Add(new Cat("Joann", 7, Gender.Female));
            animals.Add(new Cat("Layla", 4, Gender.Female));
            animals.Add(new Cat("Felton", 1, Gender.Male));
            animals.Add(new Cat("Claribel", 1, Gender.Female));
            animals.Add(new Cat("Hilton", 7, Gender.Male));
            animals.Add(new Cat("Rachell", 3, Gender.Female));
            animals.Add(new Cat("Valerie", 5, Gender.Female));
            animals.Add(new Cat("Wilber", 0, Gender.Male));
            animals.Add(new Cat("Elvira", 8, Gender.Female));
            animals.Add(new Cat("Shaun", 5, Gender.Male));
        }

        public static void AddDogs(List<Animal> animals)
        {
            animals.Add(new Dog("Gregorio", 2, Gender.Male));
            animals.Add(new Dog("Taneka", 9, Gender.Female));
            animals.Add(new Dog("Hollis", 3, Gender.Male));
            animals.Add(new Dog("Estelle", 1, Gender.Female));
            animals.Add(new Dog("Woodrow", 3, Gender.Male));
            animals.Add(new Dog("Marta", 4, Gender.Female));
            animals.Add(new Dog("August", 9, Gender.Male));
            animals.Add(new Dog("Jessika", 7, Gender.Female));
            animals.Add(new Dog("Rosann", 4, Gender.Female));
            animals.Add(new Dog("Nguyet", 9, Gender.Female));
        }

        public static void AddFrogs(List<Animal> animals)
        {
            animals.Add(new Frog("Trevor", 9, Gender.Male, "Green"));
            animals.Add(new Frog("Katelyn", 7, Gender.Female, "Gray"));
            animals.Add(new Frog("Keven", 4, Gender.Male, "Brown"));
            animals.Add(new Frog("Lennie", 1, Gender.Female, "Gray"));
            animals.Add(new Frog("Danika", 9, Gender.Female, "Green"));
            animals.Add(new Frog("Lucretia", 9, Gender.Female, "Green"));
            animals.Add(new Frog("Clarinda", 6, Gender.Female, "Gray"));
            animals.Add(new Frog("Aliza", 8, Gender.Female, "Brown"));
            animals.Add(new Frog("Deon", 1, Gender.Male, "Green"));
            animals.Add(new Frog("Dewitt", 6, Gender.Male, "Brown"));
        }

        public static void AddKitties(List<Animal> animals)
        {
            animals.Add(new Kitty("Santina", 8));
            animals.Add(new Kitty("Stefania", 1));
            animals.Add(new Kitty("Isaura", 5));
            animals.Add(new Kitty("Ai", 7));
            animals.Add(new Kitty("Cinthia", 1));
            animals.Add(new Kitty("Donya", 7));
            animals.Add(new Kitty("Crystle", 2));
            animals.Add(new Kitty("Lu", 8));
            animals.Add(new Kitty("Zella", 3));
            animals.Add(new Kitty("Maryalice", 3));
        }

        public static void AddTomcats(List<Animal> animals)
        {
            animals.Add(new Tomcat("Eldridge", 8));
            animals.Add(new Tomcat("Fredrick", 1));
            animals.Add(new Tomcat("Minh", 8));
            animals.Add(new Tomcat("Herman", 7));
            animals.Add(new Tomcat("Rodolfo", 0));
            animals.Add(new Tomcat("Emmett", 8));
            animals.Add(new Tomcat("Stevie", 4));
            animals.Add(new Tomcat("Kyle", 9));
            animals.Add(new Tomcat("Brenton", 6));
            animals.Add(new Tomcat("Trent", 2));
        }

        // http://listofrandomnames.com/index.cfm?textarea
        public static void FormatingStudentNames()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine();
                var result = input
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var toAppend = string.Format("result.Add(new Humans.Student(\"{0}\", \"{1}\", 5));", result[0], result[1]);
                builder.AppendLine(toAppend);
            }
            Console.WriteLine(builder.ToString());
        }

        public static void FormatingWorkerNames()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine();
                var result = input
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var toAppend = string.Format("result.Add(new Humans.Worker(\"{0}\", \"{1}\", 200, 40));", result[0], result[1]);
                builder.AppendLine(toAppend);
            }
            Console.WriteLine(builder.ToString());
        }

        public static void FormatAnimalsNames()
        {
            Random rng = new Random();
            var builder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine().Trim();
                var toAppend = string.Format("animals.Add(new Tomcat(\"{0}\", {1}));", input, rng.Next(10));
                builder.AppendLine(toAppend);
            }
            Console.WriteLine(builder.ToString());
        }

    }
}
