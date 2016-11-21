using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task11
{
    public class CustomLinkedList<T> : ICollection<T>, IEnumerable<T> // , LinkedList
        where T : IComparable
    {
        private const string IsNotPartOfCollectionMessage = "Node is not part of collection!";

        private Node<T> firstElement;
        private Node<T> tail;

        private int count;

        public CustomLinkedList()
        {
        }

        public CustomLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                var node = new Node<T>(item);

                if (this.firstElement == null)
                {
                    this.firstElement = node;
                    this.tail = node;
                }
                else
                {
                    this.tail.Next = node;
                    this.tail = node;
                }
            }
        }

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public Node<T> FirstElement
        {
            get { return firstElement; }
            private set { firstElement = value; }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this.AddLast(item);
        }

        public Node<T> AddAfter(Node<T> node, T value)
        {
            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (!this.isNodeExsist(node))
            {
                throw new InvalidOperationException(IsNotPartOfCollectionMessage);
            }

            var newNode = new Node<T>(value);

            newNode.Next = node.Next;
            node.Next = newNode;
            this.count++;

            return newNode;
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (this.isNullNode(newNode))
            {
                throw new ArgumentNullException("newNode");
            }

            if (!this.isNodeExsist(node))
            {
                throw new InvalidOperationException(IsNotPartOfCollectionMessage);
            }

            newNode.Next = node.Next;
            node.Next = newNode;
            this.count++;
        }

        public Node<T> AddBefore(Node<T> node, T value)
        {
            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (!this.isNodeExsist(node))
            {
                throw new InvalidOperationException(IsNotPartOfCollectionMessage);
            }

            var newNode = new Node<T>(value);

            if (this.firstElement == node)
            {
                this.firstElement = newNode;
                newNode.Next = node;
                this.count++;

                return newNode;
            }

            var current = this.firstElement;

            while (current.Next != node)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Next = node;
            this.count++;

            return newNode;
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (this.isNullNode(newNode))
            {
                throw new ArgumentNullException("newNode");
            }

            if (!this.isNodeExsist(node))
            {
                throw new InvalidOperationException(IsNotPartOfCollectionMessage);
            }

            if (this.firstElement == node)
            {
                this.firstElement = newNode;
                newNode.Next = node;
                this.count++;

                return;
            }

            var current = this.firstElement;

            while (current.Next != node)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Next = node;
            this.count++;
        }

        public Node<T> AddFirst(T value)
        {
            var node = new Node<T>(value);
            this.AddFirst(node);

            return node;
        }

        public void AddFirst(Node<T> node)
        {

            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (this.tail == null)
            {
                this.tail = node;
            }

            node.Next = this.firstElement;
            this.firstElement = node;
            this.count++;
        }

        public Node<T> AddLast(T value)
        {
            var node = new Node<T>(value);

            this.AddLast(node);

            return node;
        }

        public void AddLast(Node<T> node)
        {
            if (this.isNullNode(node))
            {
                throw new ArgumentNullException("Node");
            }

            if (this.tail == null)
            {
                this.firstElement = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                this.tail = node;
            }

            this.count++;
        }

        public void Clear()
        {
            this.firstElement = null;
            this.tail = null;
            this.count = 0;
        }

        public bool Contains(T item)
        {
            var current = this.firstElement;

            do
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    return true;
                }

                current = current.Next;

            } while (current != null);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator<T>(this.firstElement);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool isNullNode(Node<T> node)
        {
            if (node == null)
            {
                return true;
            }

            return false;
        }

        private bool isNodeExsist(Node<T> node)
        {
            Node<T> current;

            if (this.firstElement == null)
            {
                return false;
            }
            else if (this.firstElement == node)
            {
                return true;
            }
            else
            {
                current = this.firstElement;
            }

            while (current.Next != null)
            {
                if (current.Next == node)
                {
                    return true;
                }
                else
                {
                    current = current.Next;
                }
            }

            return false;
        }
    }
}
