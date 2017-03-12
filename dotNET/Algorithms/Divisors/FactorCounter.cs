using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    class FactorCounter
    {
        private int[] primeFactors = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
            127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277,
            281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457,
            461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643,
            647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839,
            853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 };

        private List<ValueFactorPair> _values = new List<ValueFactorPair>();
        private double _maxValue;
        private double _minValue;
        public int FactorizationOperationsCount { get; private set; }

        public FactorCounter(List<double> values)
        {
            foreach (double v in values)
                _values.Add(new ValueFactorPair(v));

            _maxValue = values.Max();
            _minValue = values.Min();
        }

        public int GetFactorsCount()
        {
            Dictionary<int, int> tempFactors;
            int factorCount = 0;

            foreach(var vfp in _values)
            {
                if (vfp.IsEven)
                    tempFactors = GetPrecalculated(vfp.Value, 2);
                else
                    tempFactors = GetPrecalculated(vfp.Value, 3);

                if (tempFactors == null)
                    tempFactors = CalculateFactors(vfp.Value);

                vfp.Factors = tempFactors;
                vfp.AreFactorsCalculated = true;
                factorCount += vfp.FactorCount;
            }

            return factorCount;            
        }

        public int GetFactorsCountNotOptimized()
        {
            Dictionary<int, int> tempFactors;
            int factorCount = 0;

            foreach (var vfp in _values)
            {
                tempFactors = CalculateFactors(vfp.Value);

                vfp.Factors = tempFactors;
                vfp.AreFactorsCalculated = true;
                factorCount += vfp.FactorCount;
            }

            return factorCount;
        }

        private Dictionary<int, int> GetPrecalculated(double value, int startingFactor)
        {
            if (value < 4)
                return null;

            int factorBase = startingFactor;
            int factorExponent = 1;
            double dividedValue = value / factorBase;

            int iteration = 1;

            while (dividedValue > _minValue)
            {
                ValueFactorPair vfp = _values.Find(m => m.Value == dividedValue);

                if(vfp != null)
                {
                    Dictionary<int, int> factors = new Dictionary<int, int>(vfp.Factors);

                    if (factors.TryGetValue(factorBase, out factorExponent))
                        factors[factorBase] = factorExponent + iteration;
                    else
                        factors[factorBase] = iteration;

                    return factors;
                }

                factorBase = factorBase * factorBase;
                dividedValue = value / factorBase;

                iteration++;
            }

            return null;
        }

        private Dictionary<int, int> CalculateFactors(double value)
        {
            FactorizationOperationsCount++;

            Dictionary<int, int> factors = new Dictionary<int, int>();
            int exponent = 0;

            while(value % 2 == 0)
            {
                if (factors.TryGetValue(2, out exponent))
                    factors[2] = exponent + 1;
                else
                    factors[2] = 1;

                value = (int)value / 2;
            }

            int i = 3;
            int maxFactor = (int)Math.Sqrt(value);

            while(i <= maxFactor)
            {

                while(value % i == 0)
                {
                    if (factors.TryGetValue(i, out exponent))
                        factors[i] = exponent + 1;
                    else
                        factors[i] = 1;

                    value = (int)value / i;
                    maxFactor = (int)Math.Sqrt(value);
                }

                i = i + 2;
            }

            if (value > 1)
                factors[(int)value] = 1;

            return factors;
        }

        public void PrintCollection()
        {
            foreach(var kvp in _values)
            {
                Console.Write($"{kvp.Value}:");

                foreach (var fkvp in kvp.Factors)
                    Console.Write($", [{fkvp.Key}, {fkvp.Value}]");

                Console.WriteLine();
            }
        }
    }
}
