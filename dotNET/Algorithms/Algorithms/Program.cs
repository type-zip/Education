using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sorting;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Sorting.ArrayProvider.GetCostraintedArray(10);
            //var resulta = Sorting.BasicAlgorithms.InsertionSort(new int[] { 3, 8, 2, 1, 5 });
            //var heap = Sorting.HeapSort.MakeHeap(new int[] { 1, 8, 3, 4, 2, 7, 10, 15 });

            //Sorting.HeapSort.HeapTreeVisualizer htv = new Sorting.HeapSort.HeapTreeVisualizer();
            //htv.VisualizeTree(heap);

            //Console.WriteLine();
            //Console.WriteLine();

            //var result = Sorting.HeapSort.Heapsort(heap);
            var arr = new int[] { 3, 9, 1, 5, 12, 7, 4, 8, 14, 11, 13, 24, 21, 18, 16, 19, 26, 25, 12 };
            //var arr = new int[] { 2, 4, 6, 3, 5 };
            arr.Sort();
            Console.ReadLine();
        }
    }
}
