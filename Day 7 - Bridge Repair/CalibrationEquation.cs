namespace Day_7___Bridge_Repair
{
    internal class CalibrationEquation
    {
        enum Operators
        {
            Addition,
            Multiplication,
        };

        public long ExpectedValue { get; private set; }

        readonly long[] componentValues;

        public CalibrationEquation(string rawEquation)
        {
            var data = rawEquation.Replace(":", "").Split(' ');
            ExpectedValue = long.Parse(data[0]);
            componentValues = data.Where((x, index) => index > 0).Select(long.Parse).ToArray();
        }

        public bool BruteForce(bool isPartOne)
        {
            var permutations = new List<long>()
            {
                componentValues[0]
            };

            for (int i = 1; i < componentValues.Length; i++)
            {
                var newPermutations = new List<long>();

                foreach (long value in permutations)
                {
                    long currentValue = componentValues[i];
                    long a = value + currentValue;

                    if (a <= ExpectedValue)
                    {
                        newPermutations.Add(a);
                    }

                    long b = value * currentValue;

                    if (b <= ExpectedValue)
                    {
                        newPermutations.Add(b);
                    }

                    if (isPartOne)
                    {
                        long c = long.Parse($"{value}{currentValue}");

                        if (c <= ExpectedValue)
                        {
                            newPermutations.Add(c);
                        }
                    }
                }

                permutations = newPermutations;
            }

            foreach (long value in permutations)
            {
                if (ExpectedValue == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
