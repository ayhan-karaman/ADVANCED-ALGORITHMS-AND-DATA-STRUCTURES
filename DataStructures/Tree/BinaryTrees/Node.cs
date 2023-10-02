using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTrees
{
    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }
        public Node()
        {
            
        }
        public Node(T value)
        {
            Value = value;
        }
        public override string ToString() => $"{Value}";
    }
}