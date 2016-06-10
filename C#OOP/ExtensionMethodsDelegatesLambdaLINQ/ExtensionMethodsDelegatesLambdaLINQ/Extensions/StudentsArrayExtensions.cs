namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExtensionMethodsDelegatesLambdaLINQ.LINQ;

    /// <summary>
    /// Ext methods over Student collections
    /// </summary>
    public static class StudentsArrayExtensions
    {
        // return Student collection of all students that first name is lexicographically before last
        public static IEnumerable<T> FirstBeforeLast<T>(this IEnumerable<T> students) where T : Student
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0);
            return result;
        }

        // return string collection with names of all students in specific age range
        public static IEnumerable<string> InAgeRange<T>(this IEnumerable<T> students, int min, int max) where T : Student
        {
            var result = students
                .Where(x => x.Age >= min && x.Age <= max)
                .Select(x => String.Format($"{x.FirstName} {x.LastName} {x.Age}"))
                .ToArray();
            return result;
        }

        // return Student collection sorted by decending lexicographically 1st by firstName - then by lastName
        public static IEnumerable<T> StudentsSort<T>(this IEnumerable<T> students) where T : Student
        {
            var result = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
            return result;
        }

        // return Student collection from specific group
        public static IEnumerable<T> StudentsFromGroup<T>(this IEnumerable<T> students, int group) where T : Student
        {
            var result = students
                .Where(x => x.GroupNumber == 2)
                .ToArray();
            return result;
        }

        // return Student collection by specific mail domain
        public static IEnumerable<T> StudentsByMailDomain<T>(this IEnumerable<T> students, string domain) where T : Student
        {
            var result = students
                .Where(x => x.Mail.Split('@').Last() == domain)
                .ToArray();
            return result;
        }

        //return Student collection by specific phone number group - example for specific country
        public static IEnumerable<T> StudentsByPhone<T>(this IEnumerable<T> students, int phoneGroup, string expectedGroupContain) where T : Student
        {
            var result = students
                .Where(x => x.Tel.Split(' ')
                                .Skip(phoneGroup - 1)
                                .FirstOrDefault() == expectedGroupContain)
                .ToArray();
            return result;
        }
    }
}
