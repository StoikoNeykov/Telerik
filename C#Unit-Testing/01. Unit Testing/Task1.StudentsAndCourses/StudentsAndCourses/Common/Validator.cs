namespace StudentsAndCourses.Common
{
    using System;
    using System.Collections.Generic;

    public static class Validator
    {
        public static void NullCheck(object obj, string paramName)
        {
            if (obj == null)
            {
                if (string.IsNullOrEmpty(paramName))
                {
                    paramName = "ParamName";
                }

                throw new ArgumentNullException(paramName);
            }
        }

        public static bool IsPartOfCollection<T>(IEnumerable<T> collection, T collectionMember)
        {
            NullCheck(collection, "Collection");
            NullCheck(collectionMember, "CollectionMember");

            foreach (var member in collection)
            {
                if (member.Equals(collectionMember))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
