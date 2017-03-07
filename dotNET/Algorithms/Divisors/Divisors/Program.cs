using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];

            var r = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(1, 1000);

            GetPrimeFactors(100.0);

            Console.Write("Array: ");
            PrintCollection(array);

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                var divisors = GetDivisors(array[i]);
                var primeDivisors = divisors.Where(d => IsPrimeNumber(d));
                var primeFactors = GetPrimeFactors(array[i]);

                Console.Write($" The divisors of {array[i].ToString().PadRight(3)} are:\t");
                PrintCollection(divisors);

                Console.Write($"      --- of those prime:\t");
                PrintCollection(primeDivisors);

                Console.Write($" The prime factors of {array[i].ToString().PadRight(3)} are:\t");
                PrintCollection(primeFactors);

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static List<int> GetDivisors(int n)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    divisors.Add(i);                                    
            }

            return divisors;
        }

        private static bool IsPrimeNumber(int n)
        {
            if (n % 2 == 0)
                return false; // prime numbers only divide by one and themselves, the rest are compound (I guess?) numbers

            double sqrtN = Math.Round(Math.Sqrt(n));
            
            for(int i = 2; i < sqrtN; i++)
                if (n % i == 0)
                    return false;

            return true;
        }


        private static List<double> GetPrimeFactors(double n)
        {
            //http://www.calculatorsoup.com/calculators/math/prime-factors.php

            List<double> primeFactors = new List<double>();

            double multiple = n;
            double divisor = 2;

            double divisionResult = 0;
            double divisionRemainder = 0;

            do
            {
                divisionResult = multiple / divisor;
                divisionRemainder = multiple % divisor;

                if (divisionRemainder == 0)
                {
                    primeFactors.Add(divisor);
                    multiple = multiple / divisor;
                }
                else if (divisionRemainder != 0)
                    divisor++;

            } while (divisionResult != 1);

            return primeFactors;
        }

        public static void PrintCollection(IEnumerable collection)
        {
            foreach (var i in collection)
                Console.Write(i.ToString().PadRight(4));

            Console.WriteLine();
        }
    }
}
