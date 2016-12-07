namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var currentMin = collection[i];
                var currentMinIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(currentMin) < 0)
                    {
                        currentMin = collection[j];
                        currentMinIndex = j;
                    }
                }

                if (currentMinIndex != i)
                {
                    collection[currentMinIndex] = collection[i];
                    collection[i] = currentMin;
                }
            }
        }
    }
}
