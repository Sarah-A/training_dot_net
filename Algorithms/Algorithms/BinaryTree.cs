using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class SortedBinaryNode<T> where T : struct, IComparable
    {
        public T Item { get; }
        public SortedBinaryNode<T> Left { get; set; }
        public SortedBinaryNode<T> Right { get; set; }

        public SortedBinaryNode(SortedBinaryNode<T> parent, T item) 
        {
            Item = item;
            Left = null;
            Right = null;

            if (parent == null) return;

            if(parent.Item.CompareTo(item) > 0) 
            {
                parent.Left = this;
            }
            else
            {
                parent.Right = this;
            }            
        }

        public T Value
        {
            get { return Item; }
        }
    }

    public class SortedBinaryTree<T> where T: struct, IComparable
    {
        private int _count = 0;
        private SortedBinaryNode<T> _root = null;

        public int Count
        {
            get { return _count; }
        }


        public void Add(T item)
        {
            SortedBinaryNode<T> currentNode = _root;
            SortedBinaryNode<T> parentNode = null;

            while (currentNode != null)
            {
                parentNode = currentNode;
                if (currentNode.Item.CompareTo(item) >= 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            SortedBinaryNode<T> newNode = new SortedBinaryNode<T>(parentNode, item);
            _count += 1;
            if (_root == null)
            {
                _root = newNode;
            }
        }

        private T[] DepthFirst(SortedBinaryNode<T> node)
        {
            if (node == null)
                return new T[] { };
            var leftTreeValues = DepthFirst(node.Left);
            var rightTreeValues = DepthFirst(node.Right);
            T[] fullTree = leftTreeValues
                           .Concat(new T[] { node.Value })
                           .Concat(rightTreeValues)
                           .ToArray<T>();
            return fullTree;
        }

        public T[] GetSortedVals()
        {
            return DepthFirst(_root);
        }
    }
}
