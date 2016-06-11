namespace ExtensionMethodsDelegatesLambdaLINQ.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ExtensionMethodsDelegatesLambdaLINQ.LINQ;
    using ExtensionMethodsDelegatesLambdaLINQ.Extensions;

    /// <summary>
    /// Testing LINQ methods
    /// </summary>
    public static class LINQTest
    {
        // every method from group have comments what exactly testing - just separated to be easier to check results
        public static void Test()
        {
            var students = HardCodeStudents();

            // students whos first name lexicographically before last 
            // with ext method
            var result = students.FirstBeforeLast();
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            // with normal method
            result = LINQWorks.FirstBeforeLast(students);
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            // students in age range 18-25 including
            // with ext method
            var otherResult = students.InAgeRange(18, 25);
            otherResult.ForEach(x => Console.WriteLine(x));
            PrintLine();

            // with normal method
            otherResult = LINQWorks.InAgeRange(students, 18, 25);
            otherResult.ForEach(x => Console.WriteLine(x));
            PrintLine();

            // sorted students lexicographically by decending first name - then by last name
            // with ext method
            result = students.StudentsSort();
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            // with normal method
            result = LINQWorks.StudentsSort(students);
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            // print numbers once to be seen easy
            var numbers = new[] { 4, 19, 21, 144, 48, 84, 96, 12, 7, 100, 0, 13, -5, 12, 3, 7 };
            PrintNumbers(numbers);

            // print numbers from array that can be devided by 3 AND 7 without reminder (can be changed to OR easy)
            // with ext method
            var numResult = numbers.DividebleByTwentyOne();
            PrintNumbers(numResult);

            // with normal method
            numResult = LINQWorks.DividebleByTwentyOne(numResult);
            PrintNumbers(numResult);
        }

        public static void Test2()
        {
            var students = HardCodeStudents();

            // students from group 2
            // with ext method
            students
                .StudentsFromGroup(2)
                .OrderBy(x => x.FirstName)
                .ForEach(x => Console.WriteLine($"{x.FullName} group: {x.GroupNumber}"));
            PrintLine();

            // with normal method 
            var result = LINQWorks.StudentsFromGroup(students, 2);
            result
                .OrderBy(x => x.FirstName)
                .ForEach(x => Console.WriteLine($"{x.FullName} group: {x.GroupNumber}"));
            PrintLine();

            // students with specific domain
            // with ext method
            students
                .StudentsByMailDomain("abv.bg")
                .ForEach(x => Console.WriteLine($"{x.FullName} mail: {x.Mail}"));
            PrintLine();

            // with normal method 
            result = LINQWorks.StudentsByMailDomain(students, "abv.bg");
            result
                .ForEach(x => Console.WriteLine($"{x.FullName} mail: {x.Mail}"));
            PrintLine();

            // students with phone in Sofia (+359 2 xxx xxxx) but let say all from Bulgaria so i dont check for +359 exactly
            // with ext method
            students
                .StudentsByPhone(2, "2")
                .ForEach(x => Console.WriteLine($"{x.FullName} tel.: {x.Tel}"));
            PrintLine();

            // with normal method
            result = LINQWorks.StudentsByPhone(students, 2, "2");
            result
                .ForEach(x => Console.WriteLine($"{x.FullName} tel.: {x.Tel}"));
            PrintLine();
        }

        public static void Test3()
        {
            var anonymousArray = new[]
            {
                new {FullName = "Pesho Ivanov", Marks=new List<int> { 6, 5, 2, 6, 2, 4 }},
                new {FullName = "George Petkov", Marks=new List<int> {3, 5, 3, 6, 5, 4 }},
                new {FullName = "Ivan Georgiev", Marks=new List<int> { 3, 5, 5, 6, 3, 4 }},
                new {FullName = "Stefan Varbanov", Marks=new List<int> { 2, 5, 2, 6, 2, 4 }},
                new {FullName = "Stefan Kostov", Marks=new List<int> { 3, 5, 2, 3, 2, 4 }},
                new {FullName = "Nikolay Yankov", Marks=new List<int> { 3, 5, 2, 6, 4, 4 }},
                new {FullName = "Dimityr Blagoev", Marks=new List<int> { 4, 5, 2, 6, 2, 4 }},
                new {FullName = "Hristo Gospodinov", Marks=new List<int> { 5, 5, 6, 6, 3, 4  }},
                new {FullName = "Petar Hristov", Marks=new List<int> { 4, 5, 2, 6, 4, 4 }},
                new {FullName = "Atanas Atanasov", Marks=new List<int> { 2, 5, 2, 3, 2, 4 }}
            };

            // students wit hat least 1 mark = 6
            anonymousArray
                .Where(x => x.Marks.Contains(6))
                .ForEach(x => Console.WriteLine($"{x.FullName} marks: {string.Join(" ", x.Marks)}"));
            PrintLine();

            // students with exact 2 marks = 2
            anonymousArray
                .Where(x => x.Marks
                            .Where(m => m == 2)
                            .Count() == 2)
                 .ForEach(x => Console.WriteLine($"{x.FullName} marks: {string.Join(" ", x.Marks)}"));
            PrintLine();

            var students = HardCodeStudents();

            // students from 2006
            students
                .Where(x => x.FN.ToString()[5] == '6' && x.FN.ToString()[4] == '0')
                .ForEach(x => Console.WriteLine(string.Join(" ", x.Marks)));
            PrintLine();
        }

        public static void Test4()
        {
            var students = HardCodeStudents();
            var groups = GroupsGenerator();

            // join groups and students by their GroupNumbers
            students
                 .Join(groups,
                     st => st.GroupNumber,
                     gr => gr.GroupNumber,
                     (st, gr) => new { st.FullName, gr.DepartmentName })
                 .Where(x => x.DepartmentName == "Mathematics")
                 .ForEach(x => Console.WriteLine($"{x.DepartmentName} {x.FullName}"));

            // var result = from st in students
            //              join gr in groups on st.GroupNumber equals gr.GroupNumber
            //              select new { st.FullName, gr.DepartmentName };
            //result
            //    .Where(x=>x.DepartmentName== "Mathematics")
            //    .ForEach(x => Console.WriteLine($"{x.DepartmentName} {x.FullName}"));
            PrintLine();

            var strings = GetStrings();

            // Print longest string in array of strings
            var result = strings
                .OrderByDescending(x => x.Length)
                .FirstOrDefault();
            Console.WriteLine(result);
            PrintLine();
        }

        public static void Test5()
        {
            var students = HardCodeStudents();
            // Split collection of Student to sub-collections of Student (IEnumerable<IGrouping<int, T>> where T : Student)
            // with normal method
            var result = LINQWorks.StudentsByGroups(students);
            result
                .ForEach(x =>
                {
                    Console.WriteLine($"Group: {x.Key}");
                    x.ForEach(y => Console.WriteLine($"{y.FullName}"));
                });
            PrintLine();

            // with ext method
            students
                .StudentsByGroups()
                .ForEach(x =>
                {
                    Console.WriteLine($"Group: {x.Key}");
                    x.ForEach(y => Console.WriteLine($"{y.FullName}"));
                });
            PrintLine();

            
        }

        // the new way to make methods from C# 6 
        private static void PrintLine() => Console.WriteLine("-----------------------");

        // printing numbers (I know i can use ForEach ext method but prefer been on 1 line to be easier for reading
        private static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        // Test data generators
        private static Student[] HardCodeStudents()
        {
            var result = new Student[10];
            result[0] = new Student("Pesho", "Ivanov", 20, 10230667, "+359 2 937 2211", "PeshoMail@abv.bg", new List<int> { 6, 5, 2, 6, 2, 4 }, 2);
            result[1] = new Student("George", "Petkov", 12, 10230557, "+359 2 937 2212", "GoshoMail@mail.bg", new List<int> { 3, 5, 3, 6, 5, 4 }, 3);
            result[2] = new Student("Ivan", "Georgiev", 30, 19234127, "+359 2 937 2213", "IvanMail@abv.bg", new List<int> { 3, 5, 5, 6, 3, 4 }, 2);
            result[3] = new Student("Stefan", "Varbanov", 14, 10234817, "++359 32 656 700", "Stefan2@gmail.com", new List<int> { 2, 5, 2, 6, 2, 4 }, 5);
            result[4] = new Student("Stefan", "Kostov", 23, 10230617, "+359 32 656 703", "StefanMail@yahoo.com", new List<int> { 3, 5, 2, 3, 2, 4 }, 1);
            result[5] = new Student("Nikolay", "Yankov", 18, 10230167, "+359 52 937 211", "NikovayMail@abv.bg", new List<int> { 3, 5, 2, 6, 4, 4 }, 3);
            result[6] = new Student("Dimityr", "Blagoev", 37, 16234057, "+359 42 937 211", "DimityrMail@mail.bg", new List<int> { 4, 5, 2, 6, 2, 4 }, 4);
            result[7] = new Student("Hristo", "Gospodinov", 28, 10230997, "+359 52 937 213", "HristoMail@mail.com", new List<int> { 5, 5, 6, 6, 3, 4 }, 1);
            result[8] = new Student("Petar", "Hristov", 22, 13234127, "+359 2 937 2511", "PetarMail@abv.bg", new List<int> { 4, 5, 2, 6, 4, 4 }, 1);
            result[9] = new Student("Atanas", "Atanasov", 20, 17230667, "+359 2 937 2651", "AtanasMail@dir.bg", new List<int> { 2, 5, 2, 3, 2, 4 }, 4);
            return result;
        }

        private static Group[] GroupsGenerator()
        {
            var result = new Group[5];
            result[0] = new Group(1, "Programming");
            result[1] = new Group(2, "Mathematics");
            result[2] = new Group(3, "Physics");
            result[3] = new Group(4, "Philosophy");
            result[4] = new Group(5, "Biology");

            return result;
        }

        private static string[] GetStrings()
        {
            var result = new string[10];
            result[0] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id.";
            result[1] = "Sed et feugiat lacus, vel rhoncus elit. Nulla quis ultrices magna. In fringilla nibh elit, in tempus quam posuere a.";
            result[2] = "Proin pharetra dui id est volutpat, sit amet ultrices lacus egestas. Proin luctus tellus et malesuada elementum.";
            result[3] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam nec elementum orci.";
            result[4] = "Mauris consectetur pretium justo eget tempus. Proin gravida euismod sapien ultrices facilisis.";
            result[5] = "Nunc ante sem, aliquam ut ornare nec, congue a ante. Nam viverra felis vitae arcu sodales, vitae maximus libero bibendum.";
            result[6] = "Cras arcu turpis, scelerisque et nisl eu, sodales scelerisque arcu.";
            result[7] = "Pellentesque venenatis sodales magna et venenatis. Donec ante elit, consectetur nec vulputate id, rhoncus at quam.";
            result[8] = "Vestibulum blandit semper ex et tempus. Nulla tempor, erat accumsan tincidunt ultrices, arcu mauris commodo diam, quis blandit magna eros ut odio.";
            result[9] = "Mauris congue malesuada ex, vel porta nisi cursus faucibus.";

            return result;
        }
    }
}
