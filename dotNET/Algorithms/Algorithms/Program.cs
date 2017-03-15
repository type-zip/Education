using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Sorting.ArrayProvider.GetCostraintedArray(10);
            var resulta = Sorting.BasicAlgorithms.InsertionSort(new int[] { 3, 8, 2, 1, 5 });
            var heap = Sorting.HeapSort.MakeHeap(new int[] { 1, 8, 3, 4, 2, 7, 10, 15 });

            Console.WriteLine();
            Console.WriteLine();

            var result = Sorting.HeapSort.Heapsort(heap);
            Console.ReadLine();
        }
    }
}
