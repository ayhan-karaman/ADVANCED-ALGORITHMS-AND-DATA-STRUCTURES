using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
    public interface IStack<T>
    {
        int Count { get; }
        T Pop();
        T Peek();
        void Push(T value);
    }
}