using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;
using Algorithms.Common.Types;

namespace Algorithms.Sorting
{
    public static class HeapSort
    {
        public static int[] MakeHeap(int[] array)
        {
            int[] heap = new int[array.Length];
            Array.Copy(array, heap, array.Length);

            var htv = new HeapTreeVisualizer();

            Console.WriteLine($"Initial heap state:");
            htv.VisualizeTree(heap);

            for (int i = 0; i < heap.Length; i++)
            {
                int index = i;

                while(index != 0)
                {
                    int parent = (index - 1) / 2;

                    if (heap[index] <= heap[parent])
                        break;

                    int temp = heap[index];
                    heap[index] = heap[parent];
                    heap[parent] = temp;

                    index = parent;
                }

                Console.WriteLine($"Step {i} / {array.Length}:");
                htv.VisualizeTree(heap);
            }

            return heap;
        }

        public static int RemoveTopItem(int[] heap, int elementCount)
        {
            int result = heap[0];

            heap[0] = heap[elementCount - 1];

            int index = 0;
            while (true)
            {
                int childA = 2 * index + 1;
                int childB = 2 * index + 2;

                if (childA >= elementCount)
                    childA = index;

                if (childB >= elementCount)
                    childB = index;

                if (heap[index] >= heap[childA] && heap[index] >= heap[childB])
                    break;

                int swapChild;
                if (heap[childA] > heap[childB])
                    swapChild = childA;
                else
                    swapChild = childB;

                int temp = heap[index];
                heap[index] = heap[swapChild];
                heap[swapChild] = temp;

                index = swapChild;
            }

            return result;
        }

        public static int[] Heapsort(int[] array)
        {
            int[] heap = MakeHeap(array);
            int[] result = new int[array.Length];

            var htv = new HeapTreeVisualizer();

            Console.WriteLine($"Initial heap state:");
            htv.VisualizeTree(heap);
            Console.WriteLine();
            Console.WriteLine();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int temp = heap[0];
                heap[0] = heap[i];
                heap[i] = temp;

                int index = 0;
                while (true)
                {
                    int childA = 2 * index + 1;
                    int childB = 2 * index + 2;

                    if (childA >= i)
                        childA = index;

                    if (childB >= i)
                        childB = index;

                    if (heap[index] >= heap[childA] && heap[index] >= heap[childB])
                        break;

                    int swapChild;
                    if (heap[childA] > heap[childB])
                        swapChild = childA;
                    else
                        swapChild = childB;

                    int tempValue = heap[index];
                    heap[index] = heap[swapChild];
                    heap[swapChild] = tempValue;

                    index = swapChild;
                }

                Console.WriteLine($"Heap state at iteration {i}:");
                htv.VisualizeTree(heap);
                Console.WriteLine();
                Console.WriteLine();

            }

            return heap;
        }

        public class HeapTreeVisualizer
        {
            private BinaryTreeNode BuildHeapTree(int[] heap, int rootIndex)
            {
                if (rootIndex > heap.Length - 1)
                    return null;

                int root = heap[rootIndex];
                var childA = BuildHeapTree(heap, 2 * rootIndex + 1);
                var childB = BuildHeapTree(heap, 2 * rootIndex + 2);

                var he = new BinaryTreeNode()
                {
                    Value = root,
                    Left = childA,
                    Right = childB
                };

                return he;
            }

            public void VisualizeTree(int[] heap)
            {
                var heapRoot = BuildHeapTree(heap, 0);
                heapRoot.Print();              
            }
        }
    }
}
