using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingHomework
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(IList<T> collection, int left, int right)
        {
            int i = left, j = right;
            var pivot = collection[(left + right) / 2];

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(collection, left, j);
            }

            if (i < right)
            {
                Quicksort(collection, i, right);
            }
        }
    }
}
