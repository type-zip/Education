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
            var rootA = LinkedLists.SortedLinkedListMerge.GetList(1, 10);
            var rootB = LinkedLists.SortedLinkedListMerge.GetList(5, 8);

            var result = LinkedLists.SortedLinkedListMerge.MergeSortedIterative(rootA, rootB);

            Console.ReadLine();
        }
    }
}
