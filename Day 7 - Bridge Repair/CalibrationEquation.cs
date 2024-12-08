using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7___Bridge_Repair
{
    internal class CalibrationEquation
    {
        enum Operators
        {
            Addition,
            Multiplication,
        };

        long expectedValue;
        public long ExpectedValue => expectedValue;

        long[] componentValues;
        long nrofComponent;

        public CalibrationEquation(string rawEquation)
        {
            var data = rawEquation.Replace(":", "").Split(' ');
            expectedValue = long.Parse(data[0]);
            componentValues = data.Where((x, index) => index > 0).Select(x => long.Parse(x)).ToArray();
        }

        public bool BruteForce(bool isPartOne)
        {
            var permutations = new List<long>();
            permutations.Add(componentValues[0]);

            for (int i = 1; i < componentValues.Length; i++)
            {
                var newPermutations = new List<long>();

                foreach (long value in permutations)
                {
                    long currentValue = componentValues[i];
                    long a = value + currentValue;

                    if (a <= expectedValue)
                    {
                        newPermutations.Add(a);
                    }

                    long b = value * currentValue;

                    if (b <= expectedValue)
                    {
                        newPermutations.Add(b);
                    }

                    if (isPartOne)
                    {
                        long c = long.Parse($"{value}{currentValue}");

                        if (c <= expectedValue)
                        {
                            newPermutations.Add(c);
                        }
                    }
                }

                permutations = newPermutations;
            }

            foreach (long value in permutations)
            {
                if (expectedValue == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
