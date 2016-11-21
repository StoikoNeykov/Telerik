using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task13
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> collection;

        public CustomQueue()
        {
            this.collection = new LinkedList<T>();
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            this.collection = new LinkedList<T>(collection);
        }

        public CustomQueue(int capacity)
            : this()
        {
        }

        public int Count
        {
            get
            {
                return this.collection.Count;
            }
        }

        public void Clear()
        {
            this.collection.Clear();
        }

        public void Enqueue(T item)
        {
            this.collection.AddLast(item);
        }

        public T Dequeue()
        {
            var first = this.collection.First.Value;
            this.collection.RemoveFirst();

            return first;
        }

        public T Peek()
        {
            return this.collection.First.Value;
        }

        public T[] ToArray()
        {
            return this.collection.ToArray();
        }

        public bool Contains(T item)
        {
            return this.collection.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
