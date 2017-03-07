using System;

namespace PosOfXInSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = new int[25];

            var r = new Random();

            for (int i = 0; i < values.Length; i++)
                values[i] = r.Next(0, 1000);

            Array.Sort(values);
            PrintArray(values);


            int Xvalue = values[r.Next(0, values.Length)];

            Console.WriteLine($"X is: {Xvalue}");

            int result = Solution(values, Xvalue);
            int resultRec = SolutionRecursive(values, Xvalue, 0, values.Length - 1);

            Console.WriteLine($"The position of X is: {result}");
            Console.WriteLine($"The position of X is (found recursively): {resultRec}");
            Console.ReadLine();
        }

        static int Solution(int[] sortedArray, int x)
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

        static int SolutionRecursive(int[] sortedArray, int x, int lowerBorder, int upperBorder)
        {
            int middle = (lowerBorder + upperBorder) / 2;

            if(x == sortedArray[middle])
                return (middle + 1);

            if (x > sortedArray[middle])
                return SolutionRecursive(sortedArray, x, middle + 1, upperBorder);
            else
                return SolutionRecursive(sortedArray, x, lowerBorder, middle - 1);
        }

        public static void PrintArray(int[] array)
        {
            Console.Write("Values: ");
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString().PadRight(4, ' '));
            }

            Console.WriteLine();

            Console.Write("Pos:    ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i + 1).ToString().PadRight(4, ' '));
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
