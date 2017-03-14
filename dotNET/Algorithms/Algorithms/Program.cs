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
            var rootA = LinkedLists.MergeDoublyLinkedList.GetDoublyLinkedList();
            var rootB = LinkedLists.MergeDoublyLinkedList.GetDoublyLinkedList(1, 3);

            var result = LinkedLists.MergeDoublyLinkedList.MergeDoublyLinkedLists(rootA, rootB);

            Console.ReadLine();
        }
    }
}
