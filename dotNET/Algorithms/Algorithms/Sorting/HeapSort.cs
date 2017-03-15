using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class HeapSort
    {
        public static int[] MakeHeap(int[] array)
        {
            int[] heap = new int[array.Length];
            Array.Copy(array, heap, array.Length - 1);

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

        private class HeapTreeVisualizer
        {
            private class Layer
            {
                public List<HeapElement> Elements = new List<HeapElement>();
            }

            private class HeapElement
            {
                public int Value;
                public HeapElement ChildA;
                public HeapElement ChildB;
            }

            private List<Layer> Layers = new List<Layer>();

            private HeapElement BuildHeapTree(int[] heap, int rootIndex, int layer)
            {
                if (rootIndex > heap.Length - 1)
                    return null;

                if (layer > Layers.Count - 1)
                    Layers.Add(new Layer());

                int root = heap[rootIndex];
                var childA = BuildHeapTree(heap, 2 * rootIndex + 1, layer + 1);
                var childB = BuildHeapTree(heap, 2 * rootIndex + 2, layer + 1);

                var he = new HeapElement()
                {
                    Value = root,
                    ChildA = childA,
                    ChildB = childB
                };

                Layers[layer - 1].Elements.Add(he);

                return he;
            }

            public void VisualizeTree(int[] heap)
            {
                Layers.Clear();
                var heapRoot = BuildHeapTree(heap, 0, 1);

                Layer widemostLayer = Layers.OrderBy(o => o.Elements.Count).LastOrDefault();
                int maxLayerWidth = (widemostLayer.Elements.Count) * 4;

                foreach(var l in Layers)
                {
                    int layerWidth = (l.Elements.Count) * 4;
                    int layerShift = (maxLayerWidth / 2) - (layerWidth / 2);
                    int spacing = (maxLayerWidth) / l.Elements.Count;

                    for (int i = 0; i < layerShift; i++)
                        Console.Write(" ");

                    foreach (var e in l.Elements)
                    {
                        Console.Write($"[{e.Value}]");

                        for (int s = 0; s < spacing; s++)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }                
            }
        }
    }
}
