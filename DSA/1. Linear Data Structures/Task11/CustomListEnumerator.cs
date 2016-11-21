using System;
using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    public class CustomListEnumerator<T> : IEnumerator<T>
        where T :  IComparable
    {
        private Node<T> baseNode;
        private Node<T> firstElement;
        private Node<T> currentElement;

        public CustomListEnumerator(Node<T> firstElement)
        {
            this.baseNode = new Node<T>(default(T));
            this.firstElement = firstElement;
            this.currentElement = baseNode;
        }

        public T Current
        {
            get
            {
                return this.currentElement.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.currentElement;
            }
        }

        public void Dispose()
        {
            // do nothing ofc
        }

        public bool MoveNext()
        {
            if (this.currentElement == this.baseNode)
            {
                this.currentElement = this.firstElement;
                return true;
            }

            this.currentElement = this.currentElement.Next;
            return !(this.currentElement == null);
        }

        public void Reset()
        {
            this.currentElement = this.baseNode;
        }
    }
}
