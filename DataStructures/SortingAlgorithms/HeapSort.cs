using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class HeapSort
    {
        public static void Sort<T>(T[] array)
         where T : IComparable
        {
            var heap = new Heaps.MinHeap<T>(array);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = heap.DeleteMinMax();
            }
        }
    }
}