using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.LinkedList.SinglyLinkedLists;

namespace DataStructures.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();

        public T Peek()
        {
            if(Count == 0)
                throw new Exception("Empty stack!");
            return list.Head.Value;
        }

        public T Pop()
        {
            if(Count == 0)
                throw new Exception("Empty stack!");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if(value == null)
                throw new ArgumentNullException();
            list.AddFirst(value);
            Count++;
        }
    }
}