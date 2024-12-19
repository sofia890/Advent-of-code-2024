using Day_19___Linen_Layout;

using AdventLibrary;

bool PatternIsPossible(string[] towels, string pattern)
{
    var workQueue = new PriorityQueue<string, int>();
    workQueue.Enqueue(pattern, 0);

    while (workQueue.Count > 0)
    {
        var remaining = workQueue.Dequeue();

        var choices = towels.Where(x => x.Length <= remaining.Length)
                            .Where(remaining.StartsWith)
                            .Select((x, index) => (x, index));

        foreach ((var towel, var index) in choices)
        {
            remaining = remaining[towel.Length..];

            if (remaining.Length == 0)
            {
                return true;
            }
            else
            {
                workQueue.Enqueue(remaining, remaining.Length);
            }
        }
    }

    return false;
}
long PossiblePermutations(string[] towels, string pattern)
{
    (IEnumerable<string>, long) Expand(string remaining)
    {
        long nrofDone = 0;

        var newItems = new List<string>();

        var choices = towels.Where(x => x.Length <= remaining.Length)
                            .Where(remaining.StartsWith)
                            .Select((x, index) => (x, index));

        foreach ((var towel, var index) in choices)
        {
            var newItem = remaining[towel.Length..];

            if (newItem.Length == 0)
            {
                nrofDone++;
            }
            else
            {
                newItems.Add(newItem);
            }
        }

        return (newItems, nrofDone);
    }

    return Permutations.Count(pattern, 0L, x => int.MaxValue - x.Length, Expand, x => x);
}
void PartOne(string[] towels, string[] patterns)
{
    var nrofMatches = patterns.AsParallel()
                              .Where(pattern => PatternIsPossible(towels, pattern))
                              .Count();
    Console.WriteLine($"Part One: Number of feasible patterns are {nrofMatches}.");
}
void PartTwo(string[] towels, string[] patterns)
{
    var nrofOptions = patterns.AsParallel()
                              .Select(pattern => PossiblePermutations(towels, pattern))
                              .Aggregate(0L, (a, b) => a + b);
    Console.WriteLine($"Part Two: Number of feasible permutations are {nrofOptions}.");
}

(var towels, var patterns) = Input.GetData();
PartOne(towels, patterns);
PartTwo(towels, patterns);