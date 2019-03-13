using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryNode<T>
    {
        private T _item;
        private List<BinaryNode<T>> _children;
        private BinaryNode<T> _parent;

        public BinaryNode(BinaryNode<T> parent, T item)
        {
            _children = new List<BinaryNode<T>>();
            _parent = parent;
            _item = item;
        }

        public T Value
        {
            get { return _item; }
        }
    }
}
