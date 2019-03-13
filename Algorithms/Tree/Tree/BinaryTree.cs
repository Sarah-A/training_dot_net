using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        private int _count = 0;
        private BinaryNode<T> root = null;

        public int Count 
        {
            get { return _count; }
        }


        public void Add(T item)
        {
            root = new BinaryNode<T>(null, item);
            _count += 1;
        }

        public T[] GetSortedVals()
        {
            T[] vals = new T[_count];

            if( root != null)
            {
                vals[0] = root.Value;
            }
            
            return vals;
        }
    }
}
