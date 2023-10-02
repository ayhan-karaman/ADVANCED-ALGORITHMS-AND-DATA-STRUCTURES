using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Queues;
using DataStructures.Stacks;

namespace DataStructures.Tree.BinaryTrees
{
    public class BinaryTree<T> 
    where T : IComparable
    {
        public List<Node<T>> _list { get; private set; }
        public Node<T> Root { get; set; }
        public BinaryTree()
        {
            _list = new List<Node<T>>();
        }

        public List<Node<T>> InOrder(Node<T> root)
        {
           
            if(!(root == null))
            {
                InOrder(root.Left);
                _list.Add(root);
                InOrder(root.Right);
            }
            return _list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
         {
            var list = new List<Node<T>>();
            var stack = new DataStructures.Stacks.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if(currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
         }
        
        public List<Node<T>> PreOrder(Node<T> root)
        {
            
            if(!(root == null))
            {
                 _list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }

            return _list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            
            if(root == null)
                return list;
            
                var stack =  new DataStructures.Stacks.Stack<Node<T>>();
                stack.Push(root);
                
                while (!(stack.Count == 0))
                {
                    var temp = stack.Pop();
                    list.Add(temp);
                    if(temp.Right != null)
                    {
                         stack.Push(temp.Right);
                    }
                    if(temp.Left != null)
                    {
                         stack.Push(temp.Left);
                    }
                }

                return list;
            
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
             
             if(!(root == null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                _list.Add(root);
            }
            return _list;
        }
       
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var stack1 = new DataStructures.Stacks.Stack<Node<T>>();
            var stack2 = new DataStructures.Stacks.Stack<Node<T>>();
          
            stack1.Push(root);
            while (stack1.Count > 0)
            {
               root = stack1.Pop();
               stack2.Push(root);
               if(root.Left != null)
                     stack1.Push(root.Left);
               if(root.Right != null)
                    stack1.Push(root.Right);
             
            }
            while (stack2.Count > 0)
            {
                list.Add(stack2.Pop());
            }


            return list;
        }

        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var queue = new DataStructures.Queues.Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                list.Add(temp);
                if(temp.Left != null)
                     queue.Enqueue(temp.Left);
                
                if(temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            return list;
        }
       
        public static int MaxDepth(Node<T> root)
        {
            if(root == null)
                return 0;
            var leftDepth = MaxDepth(root.Left);
            var rightDepth = MaxDepth(root.Right);

            return (leftDepth > rightDepth) ? leftDepth + 1 : rightDepth + 1;
        }
        
        public Node<T> DeepestNode(Node<T> root)
        {
            if(root == null) throw new Exception("Empty tree!");
            Node<T> temp = null;
            var q = new Queues.Queue<Node<T>>();
            q.Enqueue(root);
            
            while (q.Count > 0)
            {
                 temp = q.Dequeue();
                 if(temp.Left != null)
                     q.Enqueue(temp.Left);
                 if(temp.Right != null)
                     q.Enqueue(temp.Right);
                  
            }
            return temp;
        }
        public Node<T> DeepestNode()
        {
            var list = LevelOrderNonRecursiveTraversal(Root);
            return list[list.Count -1];
        }
        
        public static int NumberOfLeafs(Node<T> root)
        {
            if(root == null)
                throw new Exception("Empty tree!");
            int counter = 0;
            var q = new Queues.Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if(temp.Left == null && temp.Right == null)
                    counter++;
                if(temp.Left != null)
                    q.Enqueue(temp.Left);
                if(temp.Right != null)
                    q.Enqueue(temp.Right);
            }
            return counter;
        }
        public static int NumberOfLeafsLinq(Node<T> root)
        {
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
            .Where(x => x.Left == null && x.Right == null).ToList().Count;
        }

        public static int NumberOfFullNodes(Node<T> root)
        {
            var counter = 0;
            var q = new Queues.Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if(temp.Left != null && temp.Right != null)
                    counter++;
                if(temp.Left != null)
                    q.Enqueue(temp.Left);
                if(temp.Right != null)
                    q.Enqueue(temp.Right);

            }
            return counter;
        }
        public static int NumberOfFullNodesLinq(Node<T> root) => new BinaryTree<T>()
        .LevelOrderNonRecursiveTraversal(root)
        .Where(node => node.Left != null && node.Right != null).ToList().Count;


        public static int NumberOfHalfNodes(Node<T> root)
        {
            var counter = 0;
            var q = new Queues.Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if((temp.Left != null && temp.Right == null) || (temp.Left == null && temp.Right != null))
                    counter++;
                if(temp.Left != null)
                    q.Enqueue(temp.Left);
                if(temp.Right != null)
                    q.Enqueue(temp.Right);

            }
            return counter;
        }
        public static int NumberOfHalfNodesLinq(Node<T> root) => new BinaryTree<T>()
        .LevelOrderNonRecursiveTraversal(root)
        .Where(node => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
        .ToList().Count;
        
        public void PrintPaths(Node<T> root)
        {
              var path = new T[256];
              PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if(root == null) return;
            path[pathLen] = root.Value;
            pathLen++;
            if(root.Left == null && root.Right == null)
            {
                PrintArray(path, pathLen);
            }
            else
            {
                 PrintPaths(root.Left, path, pathLen);
                 PrintPaths(root.Right, path, pathLen);
            }
        }

        private void PrintArray(T[] path, int len)
        {
              for (int i = 0; i < len; i++)
                    Console.Write($"{path[i]} ");
              Console.WriteLine();
        }
        public void ListClear() => _list.Clear();
    }
}