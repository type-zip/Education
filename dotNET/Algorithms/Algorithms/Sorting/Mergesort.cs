using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class Mergesort<T> where T : IComparable
    {
        public static void BookSort(int[] data, int[] scratch, int start, int end)
        {
            if (start == end)
                return;

            int middle = (start + end) / 2;

            BookSort(data, scratch, start, middle);
            BookSort(data, scratch, middle + 1, end);

            int leftIndex = start;
            int rightIndex = middle + 1;
            int scratchIndex = leftIndex;

            while ((leftIndex <= middle) && (rightIndex <= end))
            {
                if (data[leftIndex] <= data[rightIndex])
                {
                    scratch[scratchIndex] = data[leftIndex];
                    leftIndex = leftIndex + 1;
                }
                else
                {
                    scratch[scratchIndex] = data[rightIndex];
                    rightIndex = rightIndex + 1;
                }

                scratchIndex = scratchIndex + 1;
            }

            for (int i = leftIndex; i <= middle; i++)
            {
                scratch[scratchIndex] = data[i];
                scratchIndex = scratchIndex + 1;
            }

            for (int i = rightIndex; i <= end; i++)
            {
                scratch[scratchIndex] = data[i];
                scratchIndex = scratchIndex + 1;
            }

            for (int i = start; i <= end; i++)
                data[i] = scratch[i];
        }

        public static T[] Sort(T[] data)
        {
            if (data.Length == 1)
                return data;

            int middlePoint = data.Length / 2;

            T[] left = new T[middlePoint];
            T[] right = new T[data.Length - middlePoint];

            Array.Copy(data, left, middlePoint);
            Array.Copy(data, middlePoint, right, 0, data.Length - middlePoint);

            left = Sort(left);
            right = Sort(right);

            T[] result = Merge(left, right);

            return result;
        }

        private static T[] Merge(T[] left, T[] right)
        {
            T[] result = new T[left.Length + right.Length];

            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while(rightIndex < right.Length && leftIndex < left.Length)
            {
                int comparisonResult = left[leftIndex].CompareTo(right[rightIndex]);

                if (comparisonResult <= 0)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex = leftIndex + 1;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex = rightIndex + 1;
                }

                resultIndex = resultIndex + 1;
            }

            if (rightIndex == right.Length)
            {
                for (int i = leftIndex; i < left.Length; i++)
                {
                    result[resultIndex] = left[i];
                    resultIndex = resultIndex + 1;
                }
            }

            if (leftIndex == left.Length)
            {
                for (int i = rightIndex; i < right.Length; i++)
                {
                    result[resultIndex] = right[i];
                    resultIndex = resultIndex + 1;
                }
            }


            return result;
        }
    }
}

