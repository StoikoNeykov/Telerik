namespace SortingHomework
{
    using SortingHomework;
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new Quicksorter<T>());

            var min = 0;
            var max = this.items.Count - 1;

            while (min <= max)
            {
                var mid = (max + min) / 2;
                if (this.items[mid].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.items[mid].CompareTo(item) < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var rng = new Random();

            for (int i = 0; i < this.items.Count; i++)
            {
                var random = rng.Next(0, this.items.Count);

                var temp = this.items[random];
                this.items[random] = this.items[i];
                this.items[i] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
