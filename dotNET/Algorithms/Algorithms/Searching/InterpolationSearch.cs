using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryInterpolationSearch
{
    public static class InterpolationSearch
    {
        static int SolutionInterpolationSearch(int[] sortedArray, int x)
        {
            if (sortedArray[0] == x)
                return 0;

            if (sortedArray[sortedArray.Length - 1] == x)
                return sortedArray.Length - 1;

            int lowerBorder = 0;
            int upperBorder = sortedArray.Length - 1;
            int middle = lowerBorder + (((x - sortedArray[lowerBorder]) * (upperBorder - lowerBorder)) / (sortedArray[upperBorder] - sortedArray[lowerBorder]));

            while (lowerBorder <= upperBorder)
            {
                middle = lowerBorder + (((x - sortedArray[lowerBorder]) * (upperBorder - lowerBorder)) / (sortedArray[upperBorder] - sortedArray[lowerBorder]));
                Console.WriteLine($"{middle} = {lowerBorder} + ((({x} - {sortedArray[lowerBorder]}) * ({upperBorder} - {lowerBorder})) / ({sortedArray[upperBorder]} - {sortedArray[lowerBorder]}))");

                if (x == sortedArray[middle])
                    return middle + 1;

                if (x < sortedArray[middle])
                    upperBorder = middle - 1;

                if (x > sortedArray[middle])
                    lowerBorder = middle + 1;
            }

            return -1;
        }
    }
}
