using System;

namespace Task11
{
    public class Node<T>
        where T: IComparable
    {
        private T nodeValue;

        private Node<T> next;

        public Node(T value)
        {
            this.nodeValue = value;
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        
        public T Value
        {
            get { return nodeValue; }
            set { nodeValue = value; }
        }
    }
}
