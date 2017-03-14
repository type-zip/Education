using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    class MergeDoublyLinkedList
    {
        public static DoublyLinkedCell<int> GetDoublyLinkedList(int start = 1, int amount = 10)
        {
            DoublyLinkedCell<int> listRoot = new DoublyLinkedCell<int>();
            listRoot.Value = 0;

            DoublyLinkedCell<int> previousCell = listRoot;
            DoublyLinkedCell<int> currentCell;
            
            for(int i = start; i < amount; i++)
            {
                currentCell = new DoublyLinkedCell<int>();
                currentCell.Value = i;
                currentCell.Previous = previousCell;
                previousCell.Next = currentCell;

                previousCell = currentCell;
            }

            return listRoot;
        }

        public static DoublyLinkedCell<int> MergeDoublyLinkedLists(DoublyLinkedCell<int> rootA, DoublyLinkedCell<int> rootB)
        {
            if (rootA == null)
                return rootB;

            if (rootB == null)
                return rootA;

            if(rootA.Value <= rootB.Value)
            {
                rootA.Next = MergeDoublyLinkedLists(rootA.Next, rootB);
                rootA.Next.Previous = rootA;
                rootA.Previous = null;
                return rootA;
            }
            else
            {
                rootB.Next = MergeDoublyLinkedLists(rootA, rootB.Next);
                rootB.Next.Previous = rootB;
                rootB.Previous = null;
                return rootB;
            }
        }

    }
}
