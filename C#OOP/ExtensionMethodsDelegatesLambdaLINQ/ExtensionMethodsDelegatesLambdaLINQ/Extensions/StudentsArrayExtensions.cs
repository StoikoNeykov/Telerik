namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System;
    using System.Linq;
    using ExtensionMethodsDelegatesLambdaLINQ.LINQ;

    public static class StudentsArrayExtensions
    {
        public static Student[] FirstBeforeLast(this Student[] students)
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0)
                .ToArray();
            return result;
        }

        public static string[] InAgeRange(this Student[] students, int min, int max)
        {
            var result = students
                .Where(x => x.Age >= min && x.Age <= max)
                .Select(x => String.Format($"{x.FirstName} {x.LastName} {x.Age}"))
                .ToArray();
            return result;
        }

        public static Student[] StudentsSort(this Student[] students)
        {
            var result = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
            return result;
        }
    }
}
