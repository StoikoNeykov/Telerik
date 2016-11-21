using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task12
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] collection;
        private int currentIndex;

        public CustomStack()
            : this(8)
        {
        }

        public CustomStack(IEnumerable<T> collection)
        {
            this.collection = collection.ToArray();
            this.currentIndex = this.collection.Length;
        }

        public CustomStack(int capacity)
        {
            this.collection = new T[capacity];
            this.currentIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public void Push(T item)
        {
            if (this.collection.Length == this.currentIndex)
            {
                var oldCollection = this.collection;
                this.collection = new T[oldCollection.Length * 2];

                for (int i = 0; i < oldCollection.Length; i++)
                {
                    this.collection[i] = oldCollection[i];
                }
            }

            this.collection[this.currentIndex] = item;
            this.currentIndex++;
        }

        public T Pop()
        {
            if (currentIndex == 0)
            {
                // Original stack throw with this
                // https://msdn.microsoft.com/en-us/library/system.collections.stack.pop(v=vs.110).aspx
                throw new InvalidOperationException("Stack is empty!");
            }

            var result = this.collection[this.currentIndex - 1];
            currentIndex--;

            return result;
        }

        public T Peek()
        {
            if (currentIndex == 0)
            {
                // Original stack throw with this
                // https://msdn.microsoft.com/en-us/library/system.collections.stack.pop(v=vs.110).aspx
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.collection[this.currentIndex - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            // made to work like original stack
            return this.collection.Take(this.currentIndex).Reverse().ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
