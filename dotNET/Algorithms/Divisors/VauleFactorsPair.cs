using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    public class ValueFactorPair
    {
        public double Value { get; set; }

        public bool IsEven { get; private set; }

        public bool AreFactorsCalculated { get; set; }

        public Dictionary<int, int> Factors { get; set; }

        public int FactorCount
        {
            get
            {
                int count = 0;

                foreach(var vkp in Factors)
                    count += vkp.Value;

                return count;
            }
        }

        
        public ValueFactorPair(double value)
        {
            Value = value;
            IsEven = (value % 2 == 0) ? true : false;
            Factors = new Dictionary<int, int>();
        }

        public override string ToString()
        {
            List<int> factors = new List<int>();

            foreach (var vkp in Factors)
                for (int e = 0; e < vkp.Value; e++)
                    factors.Add(vkp.Key);

            factors.Sort();

            StringBuilder factorStringBuilder = new StringBuilder();

            foreach (var f in factors)
            {
                factorStringBuilder.Append(f);
                factorStringBuilder.AppendFormat(" ");
            }

            return factorStringBuilder.ToString();
        }
    }
}
