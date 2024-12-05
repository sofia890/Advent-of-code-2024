using Day_3___Mull_It_Over;

bool ProcessPartOneUpdate(int[,] orderRules, int[] update)
{
    var InvalidCombinations = new Dictionary<(int, int), bool>();

    for (int i = 0; i < orderRules.GetLength(0); i++)
    {
        InvalidCombinations.Add((orderRules[i, 1], orderRules[i, 0]), true);
    }

    for (int i = 0; i < update.Length; i++)
    {
        for (int j = i + 1; j < update.Length; j++)
        {
            int a = update[i];
            int b = update[j];

            if (InvalidCombinations.GetValueOrDefault((a, b), false))
            {
                return false;
            }
        }
    }

    return true;
}
void ProcessPartOne(int[,] orderRules, List<int[]> updates)
{
    var middlePageNumbersSummed = 0;

    foreach (var update in updates)
    {
        if (ProcessPartOneUpdate(orderRules, update))
        {
            middlePageNumbersSummed += update[update.Length / 2];
        }
    }

    Console.WriteLine($"Part one -- Sum of all middle pages of all valid reports is {middlePageNumbersSummed}.");
}

List<int> FixPrintOrder(int[,] orderRules, int[] update)
{
    var CorrectOrders = new Dictionary<int, List<int>>();

    for (int i = 0; i < orderRules.GetLength(0); i++)
    {
        if (!CorrectOrders.ContainsKey(orderRules[i, 0]))
        {
            CorrectOrders.Add(orderRules[i, 0], new List<int>());
        }

        CorrectOrders[orderRules[i, 0]].Add(orderRules[i, 1]);
    }

    var fixedOrder = new List<int>()
    {
        update[0]
    };

    for (int i = 1; i < update.Length; i++)
    {
        int a = update[i];

        if (CorrectOrders.ContainsKey(a))
        {
            var leftOfAllThese = CorrectOrders[a];

            for (int j = 0; j < fixedOrder.Count; j++)
            {
                int b = fixedOrder[j];

                if (leftOfAllThese.Contains(b))
                {
                    fixedOrder.Insert(j, a);
                    break;
                }
            }
        }

        if (!fixedOrder.Contains(a))
        {
            fixedOrder.Add(a);
        }
    }

    return fixedOrder;
}
void ProcessPartTwo(int[,] orderRules, List<int[]> updates)
{
    var middlePageNumbersSummed = 0;

    foreach (var update in updates)
    {
        if (!ProcessPartOneUpdate(orderRules, update))
        {
            var fixedOrder = FixPrintOrder(orderRules, update);

            middlePageNumbersSummed += fixedOrder[fixedOrder.Count() / 2];
        }
    }

    Console.WriteLine($"Part two -- Sum of all middle pages of all fixed reports is {middlePageNumbersSummed}.");
}

(int[,] orderRules, List<int[]> updates) = Input.GetData();
ProcessPartOne(orderRules, updates);
ProcessPartTwo(orderRules, updates);