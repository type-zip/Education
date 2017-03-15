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
            var result = Sorting.SortingAlgorithms.BubbleSortOptimized(new int[] { 3, 8, 7, 2, 5, 1, 9});

            Console.ReadLine();
        }
    }
}
