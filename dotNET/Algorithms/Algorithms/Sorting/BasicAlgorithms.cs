using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    class BasicAlgorithms
    {
        public static int[] InsertionSort(int[] array)
        {
            // Iterate through the whole array. The i variable is going
            // to act as a separator between sorted and unsorted parts of the array
            for (int i = 0; i < array.Length; i++)
            {
                // Investigate the sorted part of the array for presence of a value that
                // is bigger than the value of an element at an index i
                for (int j = 0; j < i; j++)
                {

                    // If there is an element in the sorted part of the array with a value
                    // bigger than the value of an element i (and whose index (j) is lesser than the 
                    // index of i), then move the element from position i to position j
                    if (array[i] <= array[j])
                    {
                        // Store the value that needs to be moved
                        int iValue = array[i];

                        // Starting from the index i, set each element's value to that of the 
                        // element that preceeds it. Basicall we're just shifting array rightwards by 1 element
                        for (int s = i; s > j; s--)
                            array[s] = array[s - 1];

                        // Set the value of an element in the sorted part to
                        // the value of an element found at unsorted part
                        array[j] = iValue;
                    }
                }
            }
            
            return array;
        }

        public static int[] SelectionSort(int[] array)
        {

            // Iterate through the whole array. The i variable is going to 
            // act as a separator between sorted and unsorted parts of an array
            for (int i = 0; i < array.Length; i++)
            {
                // The variables that contain smallest value and its index
                int smallestValue = array[i];
                int smallestIndex = i;

                // Iterate through the rest of the array and find the index
                // of the smallest value
                for(int j = i; j < array.Length; j++)
                {
                    // If j contains a value smaller than the one stored in the smallestValue, update the variables
                    if(array[j] <= smallestValue)
                    {
                        smallestValue = array[j];
                        smallestIndex = j;
                    }
                }

                // If the smallestIndex is not the same as the one we're started with (i), the cycle found a variable smaller than
                // the one stored at index i and so we're need to swap those two
                if(smallestIndex != i)
                {
                    // Swap the variables, the 133t h4ck3r way
                    array[i] = array[i] ^ array[smallestIndex];
                    array[smallestIndex] = array[i] ^ array[smallestIndex];
                    array[i] = array[i] ^ array[smallestIndex];

                    /* Same operation, the ragining elementary math teacher way
                     * 
                     * array[i] = array[i] + array[smallestIndex];
                     * array[smallestIndex] = array[i] - array[smallestIndex];
                     * array[i] = array[i] - array[smallestIndex];
                     * 
                     * More info @ http://chris-taylor.github.io/blog/2013/02/25/xor-trick/
                     */
                }
            }

            return array;
        }

        public static int[] BubbleSort(int[] array)
        {
            bool notSorted = true;

            // Iterate through the array as long as the logic inside the cycle finds
            // elements that are out of order
            while (notSorted)
            {
                // Assume that array is sorted.
                notSorted = false;

                /* NOTE: the code at page 135 of "Essential Algorithms" by Rod Stephens might contain
                 * a typo that suggests that the cycle should start from the first element which semingly inevitably
                 * causes the algorithm to attempt to compare it to the element that is out of the array's lower bound
                 */

                // Iterate throught the whole array looking for the disordered pairs
                for (int i = 1; i < array.Length; i++)
                {

                    // If such pair is found, correct the order
                    if(array[i] < array[i - 1])
                    {
                        int tempValue = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tempValue;

                        // Consider array as not sorted so that the while loop does an
                        // another check. The array will be considered sorted when there won't
                        // be any disordered pairs found during the cycle
                        notSorted = true;
                    }
                }
            }

            return array;
        }

        // See page 137 of "Essential Algorithms" by Rod Stephens for more information
        public static int[] BubbleSortOptimized(int[] array)
        {
            bool notSorted = true;

            /*
             * It is safe to assume that the part of an array that follows the last swap (or preceeds the first one)
             * is already sorted so that we don't need to iterate through the whole array each time, we're only need
             * to iterate between position of the first and the last swap. The only issue is that those positions
             * shouldn't change during the passes in the same cycle.
             */
            int lastDownwardSwapIndex = array.Length;
            int lastUpwardSwapIndex = 1;

            while (notSorted)
            {
                notSorted = false;
                int lastDownwardSwapIndexCurrent = lastDownwardSwapIndex;
                int lastUpwardSwapIndexCurrent = lastUpwardSwapIndex;

                /* The idea begind downward/upward passes is that certain item might be below or above
                 * its correct position. The downward pass will move the item above its correct position
                 * to it in a single pass and in the same way the upward pass will move the item below its
                 * correct position to it.
                 */

                // Downward pass
                for (int i = lastUpwardSwapIndex; i < lastDownwardSwapIndex; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        int tempValue = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tempValue;

                        lastDownwardSwapIndexCurrent = i;

                        notSorted = true;
                    }
                }

                // Upward pass
                for (int i = lastDownwardSwapIndex; i >= lastUpwardSwapIndex; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        int tempValue = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tempValue;

                        lastUpwardSwapIndexCurrent = i;

                        notSorted = true;
                    }
                }

                // Update positons of the first and the last swap for the next iteration
                lastDownwardSwapIndex = lastDownwardSwapIndexCurrent;
                lastUpwardSwapIndex = lastUpwardSwapIndexCurrent;
            }

            return array;
        }
    }
}
