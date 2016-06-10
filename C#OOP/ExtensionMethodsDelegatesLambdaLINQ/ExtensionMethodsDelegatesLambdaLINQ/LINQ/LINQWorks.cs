namespace ExtensionMethodsDelegatesLambdaLINQ.LINQ
{
    using System;
    using System.Linq;

    public static class LINQWorks
    {
        public static Student[] FirstBeforeLast(Student[] students)
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0)
                .ToArray();
            return result;
        }

        public static string[] InAgeRange(Student[] students, int min, int max)
        {
            var result = students
                .Where(x => x.Age >= min && x.Age <= max)
                .Select(x => String.Format($"{x.FirstName} {x.LastName} {x.Age}"))
                .ToArray();
            return result;
        }

        public static Student[] StudentsSort(Student[] students)
        {
            var result = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
            return result;
        }

        public static int[] DividebleByTwentyOne(int[] numbers)
        {
            // I can make x = > x % 21 == 0; BUT if it mean by 7 OR by 3 can change it to || after ! 
            var result = numbers
                .Where(x => x % 7 == 0 && x % 3 == 0)
                .ToArray();
            return result;
        }
    }
}
