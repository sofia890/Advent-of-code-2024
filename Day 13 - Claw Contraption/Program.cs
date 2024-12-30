using Day_13___Claw_Contraption;
using static Day_13___Claw_Contraption.Input;

long SolveForB(Position goal, StepSize movementA, StepSize movementB)
{
    return (goal.X * movementA.Y - goal.Y * movementA.X) /
           (movementB.X * movementA.Y - movementB.Y * movementA.X);
}
long SolveForA(Position goal, StepSize movementA, StepSize movementB, long nrofPressesB)
{
    return (goal.X - nrofPressesB * movementB.X) / movementA.X;
}
long Solve(Position goal, StepSize movementA, StepSize movementB)
{
    long nrofPressesB = SolveForB(goal, movementA, movementB);
    long nrofPressesA = SolveForA(goal, movementA, movementB, nrofPressesB);

    if (nrofPressesA * movementA.X + nrofPressesB * movementB.X == goal.X &&
        nrofPressesA * movementA.Y + nrofPressesB * movementB.Y == goal.Y)
    {
        return CalculateCost(nrofPressesA, nrofPressesB);
    }
    else
    {
        return 0;
    }
}

long CalculateCost(long a, long b)
{
    const long COST_PER_A_PRESS = 3;
    const long COST_PER_B_PRESS = 1;
    return a * COST_PER_A_PRESS + b * COST_PER_B_PRESS;
}
Position Add(Position value)
{
    var additionalValue = 10000000000000L;
    return new Position(value.X + additionalValue, value.Y + additionalValue);
}

void PartOne(IEnumerable<Entry> items)
{
    var sum = items.Select(x => Solve(x.Goal, x.A, x.B)).Aggregate(new long(), (a, b) => a + b);

    Console.WriteLine($"Part One: Token cost is {sum}.");
}
void PartTwo(IEnumerable<Entry> items)
{
    var sum = items.Select(x => Solve(Add(x.Goal), x.A, x.B)).Aggregate(new long(), (a, b) => a + b);

    Console.WriteLine($"Part Two: Token cost is {sum}.");
}

var data = Input.GetData();
PartOne(data);
PartTwo(data);
