using System.Numerics;

namespace AdventLibrary
{
    public static class Search<RangeType> where RangeType : IComparable<RangeType>, INumber<RangeType>
    {
        static RangeType Approach(RangeType a, RangeType b)
        {
            // Scenario 1: a == b, return a
            if (a == b)
            {
                return a;
            }
            // Scenario 2: abs(a - b) == 1, return a
            else if (RangeType.Abs(a - b) == RangeType.One)
            {
                return b;
            }
            // Scenario 3: a < b, return a + half distance between a and b.
            else if (a < b)
            {
                return a + (b - a) / (RangeType.One + RangeType.One);
            }
            // Scenario 4: a > b, return a - half distance between a and b.
            else
            {
                return a - (a - b) / (RangeType.One + RangeType.One);
            }
        }
        /// <summary>
        /// Finds the threshold index where the function transitions from true to false.
        /// </summary>
        /// <param name="startIndex">The inclusive starting index for the search.</param>
        /// <param name="lastIndex">The exclusive ending index for the search.</param>
        /// <param name="func">The function to evaluate at each index.</param>
        /// <returns>The index where the function first returns false after returning true.</returns>
        public static RangeType FindThreshold(
            RangeType startIndex,
            RangeType lastIndex,
            Func<RangeType, bool> func)
        {
            RangeType lowerIndex = startIndex;
            RangeType upperIndex = lastIndex - RangeType.One;

            RangeType lowerFallbackIndex = lowerIndex;

            var lowerResult = func(lowerIndex);
            var upperResult = func(upperIndex);

            while (lowerIndex != upperIndex)
            {
                if (!lowerResult &&
                    upperResult &&
                    lowerIndex - upperIndex == RangeType.One)
                {
                    return lowerIndex;
                }
                else if (!lowerResult)
                {
                    lowerIndex = Approach(lowerIndex, upperIndex);
                    lowerResult = func(lowerIndex);
                }
                else if (!upperResult)
                {
                    upperIndex = Approach(upperIndex, lowerIndex);
                    upperResult = func(upperIndex);
                }
                else
                {
                    upperIndex = lowerIndex;
                    lowerIndex = Approach(lowerFallbackIndex, lowerIndex);

                    lowerResult = func(lowerIndex);
                    upperResult = func(upperIndex);
                }
            }

            return upperIndex;
        }
    }
}
