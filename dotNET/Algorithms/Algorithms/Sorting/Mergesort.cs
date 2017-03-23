using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort<T>(this IList<T> data) where T : IComparable
        {
            T[] bufferArray = new T[data.Count];
            Sort(data, bufferArray, 0, data.Count - 1);
        }

        public static void Sort<T>(IList<T> data, T[] buffer, int bStart, int bEnd) where T : IComparable
        {
            if (bStart == bEnd)
                return;

            int bMiddle = bStart + ((bEnd - bStart) / 2);

            Sort(data, buffer, bStart, bMiddle);
            Sort(data, buffer, bMiddle + 1, bEnd);

            int indexL = bStart;
            int indexR = bMiddle + 1;
            int bIndex = indexL;

            while ((indexL <= bMiddle) && (indexR <= bEnd))
            {

                if (data[indexL].CompareTo(data[indexR]) <= 0)
                {
                    buffer[bIndex] = data[indexL];
                    indexL++;
                }
                else
                {
                    buffer[bIndex] = data[indexR];
                    indexR++;
                }

                bIndex++;
            }

            for (int i = indexL; i <= bMiddle; i++)
            {
                buffer[bIndex] = data[i];
                bIndex++;
            }

            for (int i = indexR; i <= bEnd; i++)
            {
                buffer[bIndex] = data[i];
                bIndex++;
            }

            for (int i = bStart; i <= bEnd; i++)
                data[i] = buffer[i];
        }
    }
}

