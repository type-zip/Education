using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryInterpolationSearch
{
    class BinarySearch
    {
        static int SearchBinary(int[] sortedArray, int x)
        {
            if (sortedArray[0] == x)
                return 0;

            if (sortedArray[sortedArray.Length - 1] == x)
                return sortedArray.Length - 1;

            int lowerBorder = 0;
            int upperBorder = sortedArray.Length - 1;
            int middle = upperBorder / 2;

            while (lowerBorder <= upperBorder)
            {
                middle = (lowerBorder + upperBorder) / 2;

                if (x == sortedArray[middle])
                    return middle + 1;

                if (x < sortedArray[middle])
                    upperBorder = middle - 1;

                if (x > sortedArray[middle])
                    lowerBorder = middle + 1;
            }

            return -1;
        }

        static int RecursiveSearchBeinary(int[] sortedArray, int x, int lowerBorder, int upperBorder)
        {
            int middle = (lowerBorder + upperBorder) / 2;

            if (x == sortedArray[middle])
                return (middle + 1);

            if (x > sortedArray[middle])
                return RecursiveSearchBeinary(sortedArray, x, middle + 1, upperBorder);
            else
                return RecursiveSearchBeinary(sortedArray, x, lowerBorder, middle - 1);
        }
    }
}
