namespace ExtensionMethodsDelegatesLambdaLINQ.Tests
{
    using System;
    using System.Collections.Generic;

    using ExtensionMethodsDelegatesLambdaLINQ.LINQ;
    using ExtensionMethodsDelegatesLambdaLINQ.Extensions;

    public static class LINQTest
    {
        public static void Test()
        {
            var students = HardCodeStudents();

            var result = students.FirstBeforeLast();
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();
            result = LINQWorks.FirstBeforeLast(students);
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            var otherResult = students.InAgeRange(18, 25);
            otherResult.ForEach(x => Console.WriteLine(x));
            PrintLine();
            otherResult = LINQWorks.InAgeRange(students, 18, 25);
            otherResult.ForEach(x => Console.WriteLine(x));
            PrintLine();

            result = students.StudentsSort();
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();
            result = LINQWorks.StudentsSort(students);
            result.ForEach(x => Console.WriteLine(x.FullName));
            PrintLine();

            var numbers = new[] { 4, 19, 21, 144, 48, 84, 96, 12, 7, 100, 0, 13, -5, 12, 3, 7 };
            PrintNumbers(numbers);

            var numResult = numbers.DividebleByTwentyOne();
            PrintNumbers(numResult);
            numResult = LINQWorks.DividebleByTwentyOne(numResult);
            PrintNumbers(numResult);
        }

        private static void PrintLine()=> Console.WriteLine("-----------------------");

        private static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Student[] HardCodeStudents()
        {
            var result = new Student[10];
            result[0] = new Student("Pesho", "Ivanov", 20, 10234067, "+359 2 937 2211", "PeshoMail@abv.bg", new List<int> { 6, 5, 2, 6, 2, 4 }, 2);
            result[1] = new Student("George", "Petkov", 12, 10235057, "+359 2 937 2212", "GoshoMail@mail.bg", new List<int> { 3, 5, 3, 6, 5, 4 }, 3);
            result[2] = new Student("Ivan", "Georgiev", 30, 10234127, "+359 2 937 2213", "IvanMail@abv.bg", new List<int> { 3, 5, 5, 6, 3, 4 }, 2);
            result[3] = new Student("Stefan", "Varbanov", 14, 10234817, "++359 32 656 700", "Stefan2@gmail.com", new List<int> { 2, 5, 2, 6, 2, 4 }, 5);
            result[4] = new Student("Stefan", "Kostov", 23, 10234017, "+359 32 656 703", "StefanMail@yahoo.com", new List<int> { 3, 6, 2, 6, 2, 4 }, 1);
            result[5] = new Student("Nikolay", "Yankov", 18, 10234067, "+359 52 937 211", "NikovayMail@abv.bg", new List<int> { 3, 5, 2, 6, 4, 4 }, 3);
            result[6] = new Student("Dimityr", "Blagoev", 37, 10234057, "+359 42 937 211", "DimityrMail@mail.bg", new List<int> { 4, 5, 2, 6, 2, 4 }, 4);
            result[7] = new Student("Hristo", "Gospodinov", 28, 10234097, "+359 52 937 213", "HristoMail@mail.com", new List<int> { 5, 5, 6, 6, 3, 4 }, 7);
            result[8] = new Student("Petar", "Hristov", 22, 10234127, "+359 2 937 2511", "PetarMail@abv.bg", new List<int> { 4, 5, 2, 6, 4, 4 }, 1);
            result[9] = new Student("Atanas", "Atanasov", 20, 10234567, "+359 2 937 2651", "AtanasMail@dir.bg", new List<int> { 2, 5, 2, 3, 2, 4 }, 4);
            return result;
        }
    }
}
