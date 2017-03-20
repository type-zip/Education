using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Common
{
    public class PrintArray
    {
        public static void Print(Array a)
        {

            SwapColors();

            for (int i = 0; i < a.Length; i++)
                Console.Write($"{i}\t");

            SwapColors();

            Console.WriteLine();

            for (int i = 0; i < a.Length; i++)
                Console.Write($"{a.GetValue(i)}\t");

            Console.WriteLine();

        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }
}
