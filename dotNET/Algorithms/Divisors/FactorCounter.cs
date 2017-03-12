using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    class FactorCounter
    {
        private List<double> _values;
        private List<ValueFactorPair> _valuesFactors = new List<ValueFactorPair>();
        private double _maxValue;
        private double _minValue;
        public int FactorizationOperationsCount { get; private set; }

        public FactorCounter(List<double> values)
        {
            foreach (double v in values)
                _valuesFactors.Add(new ValueFactorPair(v));

            _values = values;
            _maxValue = values.Max();
            _minValue = values.Min();
        }

        public int GetFactorsCount()
        {
            Dictionary<int, int> tempFactors = null;
            int factorCount = 0;

            foreach(var vfp in _valuesFactors)
            {
                if (vfp.IsEven)
                {
                    tempFactors = GetPrecalculated(vfp.Value, 2);
                }
                else
                {
                    for (int i = 3; i <= 7; i = i + 2)
                    {
                        tempFactors = GetPrecalculated(vfp.Value, i);
                        if (tempFactors != null)
                            break;
                    }
                }

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

            foreach (var vfp in _valuesFactors)
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
            bool dividedEvenly = value % factorBase == 0 ? true : false;

            int iteration = 1;

            while (dividedValue > _minValue)
            {
                if (dividedEvenly)
                {
                    ValueFactorPair vfp = _valuesFactors.Find(m => m.Value == dividedValue);

                    if (vfp != null)
                    {
                        Dictionary<int, int> factors = new Dictionary<int, int>(vfp.Factors);

                        if (factors.TryGetValue(factorBase, out factorExponent))
                            factors[factorBase] = factorExponent + iteration;
                        else
                            factors[factorBase] = iteration;

                        return factors;
                    }
                }

                factorBase = factorBase * factorBase;
                dividedValue = value / factorBase;
                dividedEvenly = value % factorBase == 0 ? true : false;

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

        public List<ValueFactorPair> GetData()
        {
            return _valuesFactors;
        }

        public void PrintData()
        {
            foreach(var kvp in _valuesFactors)
            {
                Console.Write($"{kvp.Value}: {kvp.ToString()}");
                Console.WriteLine();
            }
        }
    }
}
