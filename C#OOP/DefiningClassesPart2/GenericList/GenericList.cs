namespace GenericList
{
    using System;

    public class GenericList<T> where T : IComparable
    {
        private T[] generic;

        private int index;

        public GenericList(int capacity)
        {
            this.generic = new T[capacity];
            this.index = 0;
        }

        public int NextIndex
        {
            get
            {
                return this.index;
            }
        }

        public int Capacity
        {
            get
            {
                return this.generic.Length;
            }
        }

        public void Add(T element)
        {
            this.generic[index] = element;
            this.index++;
            if (this.index == this.generic.Length)
            {
                var newGeneric = new T[this.generic.Length * 2];
                for (int i = 0; i < this.generic.Length; i++)
                {
                    newGeneric[i] = this.generic[i];
                }

                this.generic = newGeneric;
            }
        }

        public void Remove(int index)
        {
            this.OutOfRangeCheck(index);
            this.generic[index] = default(T);

        }

        public T this[int index]
        {
            get
            {
                this.OutOfRangeCheck(index);
                return this.generic[index];
            }
            set
            {
                this.OutOfRangeCheck(index);
                this.generic[index] = value;
            }
        }

        public void OutOfRangeCheck(int index)
        {
            if (index < 0 || index > this.generic.Length - 1)
            {
                throw new IndexOutOfRangeException("Index out of range! Hold your horses!");
            }
        }

        public void Clear()
        {
            for (int i = 0; i < this.generic.Length; i++)
            {
                this.generic[i] = default(T);
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.generic.Length; i++)
            {
                if (this.generic[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public int LastIndexOf(T element)
        {
            for (int i = this.generic.Length; i >= 0; i--)
            {
                if (this.generic[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public string ToString(string separator)
        {
            return string.Join(separator, this.generic);
        }

        public override string ToString()
        {
            return string.Join(", ", this.generic);
        }

        public T Min()
        {
            T min = this.generic[0];
            foreach (T element in this.generic)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.generic[0];
            foreach (T element in this.generic)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }
            return max;
        }
    }
}
