using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array)
        {
            if(type == StackType.Array)
                stack = new ArrayStack<T>();
            else
                stack = new LinkedListStack<T>();
        }

        public T Pop() => stack.Pop();
        public T Peek() => stack.Peek();
        public void Push(T value) => stack.Push(value); 

    }

    public enum StackType
    {
        Array = 0,          // List<T>
        LinkedList = 1,     //SinglyLinkedList<T> 
    }
}