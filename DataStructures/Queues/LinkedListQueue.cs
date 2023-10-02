using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.LinkedList.DoublyLinkedLists;

namespace DataStructures.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        public int Count { get; private set; }
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if(Count == 0)
                throw new Exception("Empty queue!");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Enqueue(T value)
        {
           if(value == null)
                throw new ArgumentNullException();
            list.AddLast(value);
            Count++;
        }

        public T Peek() => Count == 0 ? throw new Exception("Empty queue!") : list.Head.Value;
    }
}