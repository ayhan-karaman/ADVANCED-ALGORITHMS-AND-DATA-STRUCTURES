using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Queues
{
    public class ArrayQueue<T> : IQueue<T>
    {
         public int Count { get; private set; }
         private readonly List<T> list = new List<T>();

        public T Dequeue()
        {
            if(list.Count == 0)
                throw new Exception("Empty queue!");
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void Enqueue(T value)
        {
            if(value == null)
                throw new ArgumentNullException();
            list.Add(value);
            Count++;
        }

        public T Peek()
        {
            if(list.Count == 0)
                throw new Exception("Empty queue!");
            return list[0];
        }
    }
}