namespace BinaryTree
{
    using System;

    /// <summary>
    /// Unbalanced binary tree
    /// </summary>
    /// <typeparam name="T"> ICmparable </typeparam>
    public struct BinaryTree<T> : ICloneable
        where T : IComparable
    {
        private Node<T> root;

        private BinaryTree(Node<T> root)
        {
            this.root = new Node<T>(root);
        }

        public Node<T> Root
        {
            get
            {
                return this.root;
            }
            set
            {
                this.root = value;
            }
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Add(T data)
        {
            var forAdd = new Node<T>(data);
            if (this.IsEmpty())
            {
                this.root = forAdd;
            }
            else
            {
                root.AddNodeHere(forAdd);
            }
        }

        public bool Search(T data)
        {
            var searched = new Node<T>(data);
            if (this.IsEmpty())
            {
                return false;
            }
            else
            {
                return this.root.SearchNodeHere(searched);
            }
        }

        public void Remove(T data)
        {
            var forRemove = new Node<T>(data);
            if (this.IsEmpty())
            {
                return;
            }
            else
            {
                if (this.root.Equals(forRemove))
                {
                    this.Root = this.Root.RemoveThisNode();
                }
                else
                {
                    this.Root.FindAndRemove(forRemove);
                }
            }
        }

        public override string ToString()
        {
            return this.Root?.ToString();
        }

        public BinaryTree<T> Clone()
        {
            return new BinaryTree<T>(this.Root.DeepCopy());
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }
    }
}
