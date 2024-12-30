using Day_22___Monkey_Market;

long Mix(long secretNumber, long value)
{
    return secretNumber ^ value;
}
long Prune(long secretNumber)
{
    return secretNumber % 16777216;
}
long ForwardOnce(long secretNumber)
{
    long interimA = secretNumber * 64;
    secretNumber = Prune(Mix(secretNumber, interimA));

    long interimB = secretNumber / 32;
    secretNumber = Prune(Mix(secretNumber, interimB));

    long interimC = secretNumber * 2048;
    secretNumber = Prune(Mix(secretNumber, interimC));

    return secretNumber;
}
long ForwardRandomSequence(int seed, int steps)
{
    long secretNumber = seed;

    for (int i = 0; i < steps; i++)
    {
        secretNumber = ForwardOnce(secretNumber);
    }

    return secretNumber;
}

(long secretNumber, long change, long firstDigit) ForwardState(long secretNumber)
{
    long firstDigit = secretNumber % 10;

    secretNumber = ForwardOnce(secretNumber);

    long nextFirstDigit = secretNumber % 10;

    long change = nextFirstDigit - firstDigit;

    return (secretNumber, change, nextFirstDigit);
}
(List<string> choices, Dictionary<string, long> lookupTable) DiffSequence(int seed, int steps, Dictionary<string, long> agregation)
{
    HashSet<string> used = [];
    List<long> pattern = [];

    var (secretNumber, change, firstDigit) = ForwardState(seed);
    pattern.Add(change);

    (secretNumber, change, firstDigit) = ForwardState(secretNumber);
    pattern.Add(change);

    (secretNumber, change, firstDigit) = ForwardState(secretNumber);
    pattern.Add(change);

    List<string> elements = [];
    Dictionary<string, long> lookupTable = [];

    for (int i = 3; i < steps; i++)
    {
        (secretNumber, change, firstDigit) = ForwardState(secretNumber);
        pattern.Add(change);

        var currentPattern = pattern.TakeLast(4).Aggregate("", (a, b) => $"{a}, {b}");

        if (!used.Contains(currentPattern))
        {
            _ = used.Add(currentPattern);
            lookupTable.Add(currentPattern, firstDigit);

            agregation[currentPattern] = agregation.GetValueOrDefault(currentPattern, 0L) + firstDigit;

            elements.Add(currentPattern);
        }
    }

    return (elements, lookupTable);
}
void PartOne(IEnumerable<int> seeds, int steps)
{
    var sumOfSecrets = seeds.Select(x => ForwardRandomSequence(x, steps))
                            .Aggregate(0L, (a, b) => a + b);

    Console.WriteLine($"Part One: The sum of secrets is {sumOfSecrets}.\n");
}
void PartTwo(IEnumerable<int> seeds, int steps)
{
    Dictionary<string, long> agregation = [];

    foreach (var seed in seeds)
    {
        _ = DiffSequence(seed, steps, agregation);
    }


    long maxBananas = 0;
    int i = 0;

    foreach (var pattern in agregation.Keys)
    {
        if (i++ % 100000 == 0)
        {
            Console.WriteLine(i);
        }

        var candidate = agregation[pattern];

        if (maxBananas < candidate)
        {
            maxBananas = candidate;
        }
    }


    //var maxBananas = choices.OrderDescending().First();

    Console.WriteLine($"Part Two: The sum of secrets is {maxBananas}.\n");
}

var (seeds, steps) = Input.GetData();
PartOne(seeds, steps);
PartTwo(seeds, steps);