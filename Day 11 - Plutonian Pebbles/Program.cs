using Day_11___Plutonian_Pebbles;

(bool result, long a, long b) TrySplitNumber(long value)
{
    string data = value.ToString();
    int length = data.Length;

    if (length % 2 == 0)
    {
        int lengthOfA = length / 2;
        long a = long.Parse(data[..lengthOfA]);
        long b = long.Parse(data[lengthOfA..]);

        return (true, a, b);
    }
    else
    {
        return (false, 0, 0);
    }
}

IEnumerable<long> ProcessNumber(long value)
{
    if (value == 0)
    {
        return [1];
    }
    else if (TrySplitNumber(value) is (result: true, var a, var b))
    {
        return [a, b];
    }
    else
    {
        return [value * 2024];
    }
}

long CalculateNumberOfStones2(IEnumerable<long> numbers, int maxIterations)
{
    IEnumerable<(long value, long count)> currentSet = numbers.Select(x => (x, 1L));

    for (int i = 0; i < maxIterations; i++)
    {
        var nextSet = new List<(long value, long count)>();

        foreach (var (value, count) in currentSet)
        {
            foreach (long newNumber in ProcessNumber(value))
            {
                nextSet.Add((newNumber, count));
            }
        }

        // Numbers of the same value will be expanded to the same number of items.
        // Reduce the set to improve performance and resource usage.
        currentSet = nextSet.AsParallel()
                            .GroupBy(x => x.value)
                            .Select(x => (
                                x.First().value,
                                count: x.Aggregate(0L, (a, b) => a + b.count)
                             ));
    }

    return currentSet.Aggregate(0L, (a, b) => a + b.count);
}
void PartOne(IEnumerable<long> numbers, int iterations)
{
    Console.WriteLine($"Part One: Total number of stones is {CalculateNumberOfStones2(numbers, iterations)}.");
}
void PartTwo(IEnumerable<long> numbers, int iterations)
{
    Console.WriteLine($"Part Two: Total number of stones is {CalculateNumberOfStones2(numbers, iterations)}.");
}

(var numbers, int iterationsPartA, int iterationsPartB) = Input.GetData();
PartOne(numbers, iterationsPartA);
PartTwo(numbers, iterationsPartB);