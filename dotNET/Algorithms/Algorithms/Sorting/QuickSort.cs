using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class QuickSort
    {
        //https://www.youtube.com/watch?v=3OLTJlwyIqQ
        public static void Sort(int[] array, int start, int end)
        {
            Console.WriteLine($"QuickSort(array: {array.ToString()}, start: {start}, end: {end})");

            // If list contains only one elemnt, it's sorted
            if (start >= end)
                return;

            int divider = array[start];

            int highIndex = end;
            int lowIndex = start;

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine($"divider:\t{divider}");
                Console.WriteLine($"highIndex:\t{highIndex}");
                Console.WriteLine($"lowIndex:\t{lowIndex}");
                Console.WriteLine();
                PrintIndexes(lowIndex, highIndex, array.Length);
                Common.PrintArray.Print(array);

                // Search the array from the back to front starting at hiIndex to find the last
                // item which value is less or equal to the divider
                while(array[highIndex] >= divider)
                {
                    highIndex = highIndex - 1;

                    if (highIndex <= lowIndex)
                        break;
                }

                // Check if the left and the right indexes have met or crossed eachother
                if (highIndex <= lowIndex)
                {
                    // if so, we're going to put a divider's value at this position and consider the sorting done
                    array[lowIndex] = divider;
                    break;
                }

                // Move the found value to the lower half
                array[lowIndex] = array[highIndex];


                // Search the array from front to back starting at loIndex to find the first item
                // which value is less than the divider
                lowIndex = lowIndex + 1;
                while (array[lowIndex] < divider)
                {
                    lowIndex = lowIndex + 1;

                    if (lowIndex >= highIndex)
                        break;
                }

                if(lowIndex >= highIndex)
                {
                    lowIndex = highIndex;
                    array[highIndex] = divider;
                    break;
                }

                array[highIndex] = array[lowIndex];

            }

            Sort(array, start, lowIndex - 1);
            Sort(array, lowIndex + 1, end);
        }

        private static void PrintIndexes(int low, int high, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (i == low)
                    Console.Write("L");

                if (i == high)
                    Console.Write("H");

                Console.Write("\t");
            }

            Console.WriteLine();
        }
    }
}
