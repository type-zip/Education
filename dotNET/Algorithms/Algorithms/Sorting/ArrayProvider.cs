using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
   
    public static class ArrayProvider
    {

        /// <summary>
        /// Creates the array of size N with elements range [0..M] where M < N
        /// </summary>
        /// <param name="N">The amount of elements in the array</param>
        public static int[] GetCostraintedArray(int N = 100)
        {
            int[] array = new int[N];
            int M = N - 2;

            Random rg = new Random();

            for (int i = 0; i < N; i++)
            {
                array[i] = rg.Next(0, M);
            }

            return array;
        }
    }
}
