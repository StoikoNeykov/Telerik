namespace ExtensionMethodsDelegatesLambdaLINQ.LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LINQWorks
    {
        // return collection of students whos first name is before last lexicographically
        public static IEnumerable<T> FirstBeforeLast<T>(IEnumerable<T> students) where T : Student
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0)
                .ToArray();
            return result;
        }

        //return collection of students in specific age interval. Actually their full names as strings
        public static IEnumerable<string> InAgeRange<T>(IEnumerable<T> students, int min, int max) where T : Student
        {
            var result = students
                .Where(x => x.Age >= min && x.Age <= max)
                .Select(x => String.Format($"{x.FirstName} {x.LastName} {x.Age}"))
                .ToArray();
            return result;
        }

        // return collection of students sorted lexicographically by decending 1st by first name then by last name
        public static IEnumerable<T> StudentsSort<T>(IEnumerable<T> students) where T : Student
        {
            var result = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();
            return result;
        }

        // return array of numbers that can be divided by 3 AND 7 without reminder
        public static int[] DividebleByTwentyOne(int[] numbers)
        {
            // I can make x = > x % 21 == 0; BUT if it mean by 7 OR by 3 can change it to || after ! 
            var result = numbers
                .Where(x => x % 7 == 0 && x % 3 == 0)
                .ToArray();
            return result;
        }

        // return collection of students from specific group
        public static IEnumerable<T> StudentsFromGroup<T>(IEnumerable<T> students, int group) where T : Student
        {
            var result = students
                .Where(x => x.GroupNumber == 2)
                .ToArray();
            return result;
        }

        // return collection of students with specific mail domain
        public static IEnumerable<T> StudentsByMailDomain<T>(IEnumerable<T> students, string domain) where T : Student
        {
            var result = students
                .Where(x => x.Mail.Split('@').Last() == domain)
                .ToArray();
            return result;
        }

        // return collection of students with specific phone number group (can be used to find person from specific coutry for example)
        public static IEnumerable<T> StudentsByPhone<T>(IEnumerable<T> students, int phoneGroup, string expectedGroupContain) where T : Student
        {
            var result = students
                .Where(x => x.Tel.Split(' ')
                                .Skip(phoneGroup - 1)
                                .FirstOrDefault() == expectedGroupContain)
                .ToArray();
            return result;
        }

        public static IEnumerable<IGrouping<int, T>> StudentsByGroups<T>(IEnumerable<T> students) where T : Student
        {
            var result = students
                .OrderBy(x => x.GroupNumber)
                .GroupBy(x => x.GroupNumber);
            return result;
        }
    }
}
