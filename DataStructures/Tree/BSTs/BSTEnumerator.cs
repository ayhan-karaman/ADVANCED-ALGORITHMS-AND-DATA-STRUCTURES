using System.Collections;
using DataStructures.Tree.BinaryTrees;

namespace DataStructures.Tree.BSTs
{
    internal class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> _list;
        private int indexer = -1;

        public BSTEnumerator(Node<T> root) => _list = new BinaryTree<T>().InOrderNonRecursiveTraversal(root);
        

        public T Current => _list[indexer].Value;

        object IEnumerator.Current => Current;

        public void Dispose() => _list = null;
        

        public bool MoveNext()
        {
            indexer++;
            return indexer < _list.Count ? true : false;
        }

        public void Reset() => indexer = -1;
        
    }
}