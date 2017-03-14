using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    class MergeLinkedList
    {
        public static Cell<int> GetList(int start = 1, int amount = 10)
        {
            Cell<int> root = new Cell<int>();
            root.Value = start;

            Cell<int> previous = root;
            for (int i = start + 1; i < amount; i++)
            {
                Cell<int> temp = new Cell<int>();
                temp.Value = i;
                previous.Next = temp;
                previous = temp;
            }

            return root;
        }

        public static Cell<int> MergeSorted(Cell<int> rootA, Cell<int> rootB)
        {
            if (rootA == null)
                return rootB;

            if (rootB == null)
                return rootA;

            Cell<int> resultRoot = new Cell<int>();

            if(rootA.Value <= rootB.Value)
            {
                resultRoot.Value = rootA.Value;
                resultRoot.Next = MergeSorted(rootA.Next, rootB);
            }
            else
            {
                resultRoot.Value = rootB.Value;
                resultRoot.Next = MergeSorted(rootA, rootB.Next);
            }

            return resultRoot;
        }

        public static Cell<int> MergeSortedIterative(Cell<int> rootA, Cell<int> rootB)
        {
            if (rootA == null)
                return rootB;

            if (rootB == null)
                return rootA;

            Cell<int> resultRoot = new Cell<int>();

            if (rootA.Value <= rootB.Value)
                resultRoot = rootA;
            else
                resultRoot = rootB;

            while(rootA.Next != null)
            {
                if(rootA.Next.Value > rootB.Value)
                {
                    Cell<int> temp = rootA.Next;
                    rootA.Next = rootB;
                    rootB = temp;
                }

                rootA = rootA.Next;
            }

            if (rootA.Next == null)
                rootA.Next = rootB;

            return resultRoot;
        }

        public static Cell<int> MergeWithoutAdditionalMemoryRecursive(Cell<int> rootA, Cell<int> rootB)
        {
            if (rootA == null)
                return rootB;

            if (rootB == null)
                return rootA;

            if (rootA.Value <= rootB.Value)
            {
                rootA.Next = MergeSorted(rootA.Next, rootB);
                return rootA;
            }
            else
            {
                rootB.Next = MergeSorted(rootA, rootB.Next);
                return rootB;
            }
        }
    }
}
