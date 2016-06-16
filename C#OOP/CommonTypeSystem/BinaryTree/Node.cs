namespace BinaryTree
{
    using System;

    /// <summary>
    /// Represent node in binary tree
    /// </summary>
    /// <typeparam name="T"> IComparable -> cannot make binary tree without compare elements </typeparam>
    public class Node<T> : IComparable where T : IComparable
    {
        private T data;

        public Node(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        internal Node(Node<T> forCopy)
        {
            this.Data = forCopy.Data;
            this.Left = forCopy.Left?.DeepCopy();
            this.Right = forCopy.Right?.DeepCopy();
        }

        public T Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public void AddNodeHere(Node<T> forAdd)
        {
            if (this.CompareTo(forAdd) == 0)
            {
                throw new ArgumentException("Nodes are equals!");
            }

            if (this.CompareTo(forAdd) < 0)
            {
                if (this.Right == null)
                {
                    this.Right = forAdd;
                }
                else
                {
                    this.Right.AddNodeHere(forAdd);
                }
            }
            else
            {
                if (this.Left == null)
                {
                    this.Left = forAdd;
                }
                else
                {
                    this.Left.AddNodeHere(forAdd);
                }
            }
        }

        public bool SearchNodeHere(Node<T> searched)
        {
            if (this.CompareTo(searched) == 0)
            {
                return true;
            }
            else if (this.CompareTo(searched) < 0)
            {
                if (this.Right == null)
                {
                    return false;
                }

                this.Right.SearchNodeHere(searched);
            }
            else
            {
                if (this.Left == null)
                {
                    return false;
                }

                this.Left.SearchNodeHere(searched);
            }

            return false;
        }

        // need reworking still but working 
        public Node<T> RemoveThisNode()
        {
            if (this.Left == null & this.Right == null)
            {
                return null;
            }
            else if (this.Left == null)
            {
                return this.Right;
            }
            else if (this.Right == null)
            {
                return this.Left;
            }
            else
            {
                T minData = this.Right.FindMin();
                this.Data = minData;
                if (this.Right.Data.Equals(minData))
                {
                    this.Right = this.Right.RemoveThisNode();
                }
                else
                {
                    this.Right.RemoveMin(minData);
                }
                return this;
            }
        }

        private void RemoveMin(T minData)
        {
            if (this.Left.Data.Equals(minData))
            {
                this.Left = this.Left.RemoveThisNode();
            }
            else
            {
                this.Left.RemoveMin(minData);
            }
        }

        private T FindMin()
        {
            if (this.Left == null)
            {
                return this.Data;
            }
            else
            {
                return this.Left.FindMin();
            }
        }

        public void FindAndRemove(Node<T> forRemove)
        {
            if (this.CompareTo(forRemove) < 0)
            {
                if (this.Right == null)
                {
                    return;
                }

                if (this.Right.CompareTo(forRemove) == 0)
                {
                    this.Right = this.Right.RemoveThisNode();
                }
                else
                {
                    this.Right.FindAndRemove(forRemove);
                }
            }
            else
            {
                if (this.Left == null)
                {
                    return;
                }

                if (this.Left.CompareTo(forRemove) == 0)
                {
                    this.Left = this.Left.RemoveThisNode();
                }
                else
                {
                    this.Left.FindAndRemove(forRemove);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{1} {0} {2}",
                this.Data.ToString(),
                this.Left?.ToString(),
                this.Right?.ToString()).Trim();
        }

        public override bool Equals(object node)
        {
            if (!(node is Node<T>))
            {
                return false;
            }

            var other = node as Node<T>;
            return this.Data.Equals(other.Data);
        }

        public override int GetHashCode()
        {
            return this.Data.GetHashCode();
        }

        public int CompareTo(object node)
        {
            if (!(node is Node<T>))
            {
                throw new ArgumentException("Object is not a Node<T>!");
            }

            var other = node as Node<T>;
            return this.CompareTo(other);
        }

        public int CompareTo(Node<T> other)
        {
            return this.Data.CompareTo(other.Data);
        }

        public static bool operator ==(Node<T> first, Node<T> second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Node<T> first, Node<T> second)
        {
            return !(first == second);
        }

        public Node<T> DeepCopy()
        {
            return new Node<T>(this);
        }

        // carefully ! 
        public static T operator +(Node<T> first, Node<T> second)
        {
            return second.Data;

        }
    }
}
