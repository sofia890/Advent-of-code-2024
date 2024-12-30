using Day_5___Print_Queue;

bool ProcessPartOneUpdate(List<int[]> orderRules, int[] update)
{
    var InvalidCombinations = new Dictionary<(int, int), bool>();

    for (int i = 0; i < orderRules.Count; i++)
    {
        InvalidCombinations.Add((orderRules[i][1], orderRules[i][0]), true);
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
void PartOne(List<int[]> orderRules, List<int[]> updates)
{
    var middlePageNumbersSummed = 0;

    foreach (var update in updates)
    {
        if (ProcessPartOneUpdate(orderRules, update))
        {
            middlePageNumbersSummed += update[update.Length / 2];
        }
    }

    Console.WriteLine($"Part One: Sum of all middle pages of all valid reports is {middlePageNumbersSummed}.");
}

List<int> FixPrintOrder(List<int[]> orderRules, int[] update)
{
    var CorrectOrders = new Dictionary<int, List<int>>();

    for (int i = 0; i < orderRules.Count; i++)
    {
        if (!CorrectOrders.TryGetValue(orderRules[i][0], out var otherItem))
        {
            otherItem = [];
            CorrectOrders.Add(orderRules[i][0], otherItem);
        }

        otherItem.Add(orderRules[i][1]);
    }

    var fixedOrder = new List<int>()
    {
        update[0]
    };

    for (int i = 1; i < update.Length; i++)
    {
        int a = update[i];

        if (CorrectOrders.TryGetValue(a, out var leftOfAllThese))
        {
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
void PartTwo(List<int[]> orderRules, List<int[]> updates)
{
    var middlePageNumbersSummed = 0;

    foreach (var update in updates)
    {
        if (!ProcessPartOneUpdate(orderRules, update))
        {
            var fixedOrder = FixPrintOrder(orderRules, update);

            middlePageNumbersSummed += fixedOrder[fixedOrder.Count / 2];
        }
    }

    Console.WriteLine($"Part One: Sum of all middle pages of all fixed reports is {middlePageNumbersSummed}.");
}

(var orderRules, var updates) = Input.GetData();
PartOne(orderRules, updates);
PartTwo(orderRules, updates);