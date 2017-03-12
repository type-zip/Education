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
            List<double> elements = new List<double>();
            Random rg = new Random();

            for (int i = 1; i <= 50000; i++)
                elements.Add(i);

            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            FactorCounter fc = new FactorCounter(elements);
            Console.WriteLine(fc.GetFactorsCount());
            stopwatch.Stop();
            //fc.PrintCollection();
            Console.WriteLine($"Calculation took: {stopwatch.ElapsedMilliseconds} ms.");

            Console.ReadLine();

            stopwatch.Restart();
            Console.WriteLine(fc.GetFactorsCount());
            stopwatch.Stop();
            Console.WriteLine($"Non-optimized calculation took: {stopwatch.ElapsedMilliseconds} ms.");

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
            int cycles = 0;

            if (n % 2 == 0)
                return false; // prime numbers only divide by one and themselves, the rest are compound (I guess?) numbers

            double sqrtN = Math.Round(Math.Sqrt(n));

            for (int i = 2; i < sqrtN; i++)
            {
                cycles++;

                if (n % i == 0)
                {
                    Console.WriteLine($"Prime test cycles: {cycles}");
                    return false;
                }
            }

            Console.WriteLine($"Prime test cycles: {cycles}");
            return true;
        }

        private static bool IsPrimeNumberFermat(int p, int maxTests = 10)
        {
            int cycles = 0;

            Random gen = new Random();

            for (int i = 0; i < maxTests; i++)
            {
                cycles++;
                int n = gen.Next(0, p);

                if (Math.Pow(n, (p - 1)) % p != 1)
                {
                    Console.WriteLine($"Fermat prime test cycles: {cycles}");
                    return false;
                }
            }

            Console.WriteLine($"Fermat prime test cycles: {cycles}");
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
