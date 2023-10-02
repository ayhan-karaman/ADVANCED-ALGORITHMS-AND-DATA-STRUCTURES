using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Queues
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;
        public Queue(QueueType type = QueueType.Array)
        {
            if(type == QueueType.Array)
            {
                queue = new ArrayQueue<T>();
            }
            else
            {
                queue = new LinkedListQueue<T>();
            }
        }

        public void Enqueue(T value) => queue.Enqueue(value);

        public T Dequeue() => queue.Dequeue();
        public T Peek() => queue.Peek();
    }
    public interface IQueue<T>
    {
        int Count { get; }
        void Enqueue(T value);
        T Dequeue();
        T Peek();
    }
    public enum QueueType
    {
        Array  = 0,         // List<T>
        LinkedList = 1      // DoublyLinkedList<T>
    }
}