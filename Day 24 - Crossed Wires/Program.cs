using Day_24___Crossed_Wires;

const string AND = "AND";
const string OR = "OR";
const string XOR = "XOR";
long GetNumber(Dictionary<string, int> registers, char registerGroup)
{
    var resultRegisters = registers.Where(x => x.Key[0] == registerGroup)
                                   .Select(x => (register: x.Key, index: int.Parse(x.Key[1..]), value: x.Value))
                                   .Order();

    long result = 0;

    foreach (var currentRegister in resultRegisters)
    {
        result |= (long)currentRegister.value << currentRegister.index;
    }

    return result;
}
long Run(Dictionary<string, int> registers, List<Operation> operations, bool verbose = false)
{
    while (operations.Any())
    {
        var readyOperations = operations.Where(x => x.IsReady(registers)).ToArray();

        if (verbose)
        {
            var firstLevelRegisters = readyOperations.Select(x => x.OutA)
                                                     .Aggregate("", (a, b) => $"{a}, {b}")[2..];
            Console.WriteLine(firstLevelRegisters);
        }

        foreach (var operation in readyOperations)
        {
            var (value, targetRegister) = operation.Perform(registers, verbose);
            registers[targetRegister] = value;

            operations.Remove(operation);
        }
    }

    return GetNumber(registers, 'z');
}
string ReplaceOutputs(
    Dictionary<string, Operation> lookup,
    List<Operation> operations,
    List<string> swapped,
    Operation operation,
    Func<Operation, bool> critera)
{
    var other = operations.FirstOrDefault(critera, new("", "", "", ""));

    if (other.OutA != string.Empty)
    {
        Console.WriteLine($"{operation.OutA}<->{other.OutA}");

        if (other != null)
        {
            var temp = operation.OutA;
            operation.OutA = other.OutA;
            other.OutA = temp;

            lookup[operation.OutA] = operation;
            lookup[other.OutA] = other;

            swapped.AddRange([operation.OutA, other.OutA]);

            return operation.OutA;
        }
        else
        {
            return string.Empty;
        }
    }
    else
    {
        return string.Empty;
    }
}
Func<Operation, bool> CreateFindSearchForNodeC(string accumulatorName)
{
    return x =>
    {
        if (x is (var inA, var inB, var action, _) &&
            (inA == accumulatorName || inB == accumulatorName) &&
            action == AND)
        {
            return true;
        }
        else
        {
            return false;
        }
    };
}
Func<Operation, bool> CreateFindSearchForNodeA(Dictionary<string, Operation> lookup, string xIdentifier, string yIdentifier)
{
    return x =>
    {
        if (x is (var inA, var inB, var action, _) &&
            inA[0] != 'x' &&
            inA[0] != 'y' &&
            inB[0] != 'x' &&
            inB[0] != 'y' &&
            action == XOR &&
            ((lookup[inA] is (_, _, OR, _) &&
              lookup[inB] is (var aNN1, var bNN1, XOR, _) &&
              ((aNN1 == xIdentifier && bNN1 == yIdentifier) ||
               (aNN1 == yIdentifier && bNN1 == xIdentifier))) ||
             (lookup[inA] is (var aNN2, var bNN2, XOR, _) &&
              lookup[inB] is (_, _, OR, _) &&
              ((aNN2 == xIdentifier && bNN2 == yIdentifier) ||
               (aNN2 == yIdentifier && bNN2 == xIdentifier)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    };
}
bool IsNodeC(Dictionary<string, Operation> lookup, Operation c, string accumulatorName)
{
    var (cSide1, cSide2, _, _) = c;

    return (cSide1 == accumulatorName && lookup[cSide2] is (_, _, XOR, _)) ||
           (cSide2 == accumulatorName && lookup[cSide1] is (_, _, XOR, _));
}
(Operation, string) HandleNodeB(Dictionary<string, Operation> lookup,
                                List<Operation> operations,
                                List<string> swapped,
                                int depth,
                                string accumulatorName,
                                Operation originSide1,
                                Operation originSide2)
{
    var originidentifier = $"z{depth:00}";

    string unusedSide = string.Empty;

    Operation b;

    if (originSide1 is (_, _, OR, _))
    {
        b = originSide1;
        unusedSide = originSide2.OutA;
    }
    else if (originSide2 is (_, _, OR, _))
    {
        b = originSide2;
        unusedSide = originSide1.OutA;
    }
    else
    {
        throw new Exception();
    }

    var (bSide1, bSide2, _, _) = b;

    if (lookup[bSide1] is not (_, _, AND, _) &&
        lookup[bSide2] is not (_, _, AND, _))
    {
        throw new NotImplementedException();
    }
    else if (lookup[bSide1] is not (_, _, AND, _) &&
             IsNodeC(lookup, lookup[bSide1], accumulatorName))
    {
        bSide1 = ReplaceOutputs(lookup, operations, swapped, lookup[bSide2], CreateFindSearchForNodeC(accumulatorName));
    }
    else if (lookup[bSide2] is not (_, _, AND, _) &&
             IsNodeC(lookup, lookup[bSide2], accumulatorName))
    {
        bSide2 = ReplaceOutputs(lookup, operations, swapped, lookup[bSide2], CreateFindSearchForNodeC(accumulatorName));
    }

    //
    // E node
    //
    var previousDepth = depth - 1;
    var xPreviousIdentifier = $"x{previousDepth:00}";
    var yPreviousIdentifier = $"y{previousDepth:00}";
    var (bSide1Side1, bSide1Side2, _, _) = lookup[bSide1];
    var (bSide2Side1, bSide2Side2, _, _) = lookup[bSide2];
    Operation c;
    Operation e;

    if ((bSide1Side1 == xPreviousIdentifier && bSide1Side2 == yPreviousIdentifier) ||
        (bSide1Side1 == yPreviousIdentifier && bSide1Side2 == xPreviousIdentifier))
    {
        c = lookup[bSide2];
        e = lookup[bSide1];
    }
    else if ((bSide2Side1 == xPreviousIdentifier && bSide2Side2 == yPreviousIdentifier) ||
             (bSide2Side1 == yPreviousIdentifier && bSide2Side2 == xPreviousIdentifier))
    {
        c = lookup[bSide1];
        e = lookup[bSide2];
    }
    else
    {
        throw new Exception($"Could not find E node for {originidentifier}; {bSide1Side1}, " +
                            $"{bSide1Side2}, {bSide2Side1}, {bSide2Side2}!");
    }

    //
    // C node
    //
    Operation d = HandleNodeC(lookup, c, accumulatorName, originidentifier);

    //
    // D node
    //
    var (dSide1, dSide2, _, _) = d;

    if (!((dSide1 == xPreviousIdentifier && dSide2 == yPreviousIdentifier) ||
          (dSide1 == yPreviousIdentifier && dSide2 == xPreviousIdentifier)))
    {
        throw new Exception($"Could not find D node for {originidentifier}; {dSide1}, {dSide2}!");
    }

    //
    // Done
    //
    return (b, unusedSide);
}
Operation HandleNodeC(Dictionary<string, Operation> lookup, Operation c, string accumulatorName, string originidentifier)
{
    var (cSide1, cSide2, _, _) = c;
    Operation d;

    if (cSide1 == accumulatorName && lookup[cSide2] is (_, _, XOR, _))
    {
        d = lookup[cSide2];
    }
    else if (cSide2 == accumulatorName && lookup[cSide1] is (_, _, XOR, _))
    {
        d = lookup[cSide1];
    }
    else
    {
        throw new Exception($"Could not find C node for {originidentifier}; {c}!");
    }

    return d;
}
List<string> GetResultRegisterData(Dictionary<string, int> registers, List<Operation> operations, bool verbose = false)
{
    var nrOfInputRegisters = registers.Count / 2;

    Dictionary<string, Operation> lookup = new();

    foreach (var current in operations)
    {
        lookup[current.OutA] = current;
    }

    List<string> swapped = new();

    string accumulatorName = "pkm";

    for (int depth = 5; depth < nrOfInputRegisters; depth++)
    {
        // Example for z05:
        //                   z05
        //                    |
        //        ---------- XOR -------------
        //       |<rdh                      |<pst
        // y05-- XOR --x05              ---- OR -------------
        //                              |                   |
        //                              |                   |<pgh
        //                              |            y04-- AND --x04
        //                              |<wfw
        //                        ---- AND ---- pkm
        //                        |<rhk        
        //                 yNn-- XOR --xNn

        // Generic for zNN:
        // |Where yNN ís bit on the same bit index as output.
        // |Where yNn is bit from one level down towards least significant bit.
        //
        //                  Origin
        //                    |
        //        ---------- XOR -------------
        //       |<A                         |<B
        // yNN-- XOR --xNN              ---- OR -------------
        //                              |                   |
        //                              |                   |<E
        //                              |            yNn-- AND --xNn
        //                              |<C
        //                        ---- AND ---- Accum
        //                        |<D        
        //                 yNn-- XOR --xNn

        //
        // Origin node
        //
        var xIdentifier = $"x{depth:00}";
        var yIdentifier = $"y{depth:00}";
        var originidentifier = $"z{depth:00}";
        var (originSide1Name, originSide2Name, _, _) = lookup[originidentifier];
        Operation originSide1;
        Operation originSide2;


        if (originSide1Name[0] == 'x' || originSide1Name[0] == 'y' ||
            originSide2Name[0] == 'x' || originSide2Name[0] == 'y')
        {
            _ = ReplaceOutputs(lookup,
                               operations,
                               swapped,
                               lookup[originidentifier],
                               CreateFindSearchForNodeA(lookup, xIdentifier, yIdentifier));

            (originSide1Name, originSide2Name, _, _) = lookup[originidentifier];
            originSide1 = lookup[originSide1Name];
            originSide2 = lookup[originSide2Name];
        }
        else
        {
            originSide1 = lookup[originSide1Name];
            originSide2 = lookup[originSide2Name];

            if (!((originSide1 is (_, _, OR, _) && originSide2 is (_, _, XOR, _)) ||
                  (originSide1 is (_, _, XOR, _) && originSide2 is (_, _, OR, _))))
            {
                // Does not handle: mmf <-> sjd
                var replacement = ReplaceOutputs(lookup,
                                                 operations,
                                                 swapped,
                                                 lookup[originidentifier],
                                                 CreateFindSearchForNodeA(lookup, xIdentifier, yIdentifier));

                if (replacement != string.Empty)
                {
                    (originSide1Name, originSide2Name, _, _) = lookup[originidentifier];
                    originSide1 = lookup[originSide1Name];
                    originSide2 = lookup[originSide2Name];
                }
                else
                {
                    // Fixing node B might sort out the incorrect mapping and even if it does not
                    // we will know how to fix a single missing node.
                    (_, var unused) = HandleNodeB(lookup,
                                                  operations,
                                                  swapped,
                                                  depth,
                                                  accumulatorName,
                                                  originSide1,
                                                  originSide2);

                    if (lookup[unused] is not (_, _, XOR, _))
                    {
                        ReplaceOutputs(lookup,
                                       operations,
                                       swapped,
                                       lookup[unused],
                                       x => x is (var inA, var inB, XOR, _) &&
                                            ((inA == xIdentifier && inB == yIdentifier) ||
                                             (inA == yIdentifier && inB == xIdentifier)));
                    }

                    (originSide1Name, originSide2Name, _, _) = lookup[originidentifier];
                    originSide1 = lookup[originSide1Name];
                    originSide2 = lookup[originSide2Name];
                }
            }
        }

        Operation a;

        if (originSide1 is (_, _, XOR, _))
        {
            a = originSide1;
        }
        else if (originSide2 is (_, _, XOR, _))
        {
            a = originSide2;
        }
        else
        {
            throw new Exception($"Could not find origin node for {originidentifier}!");
        }

        //
        // A node
        //
        var (aSide1, aSide2, _, _) = a;

        if (!(aSide1 == xIdentifier && aSide2 == yIdentifier) &&
            !(aSide1 == yIdentifier && aSide2 == xIdentifier))
        {
            throw new Exception($"Could not find A node for {originidentifier}!");
        }

        //
        // B node
        //
        var (b, _) = HandleNodeB(lookup,
                                 operations,
                                 swapped,
                                 depth,
                                 accumulatorName,
                                 originSide1,
                                 originSide2);

        //
        // Advance accumulator tracking
        //
        accumulatorName = b.OutA;
    }

    return swapped;
}
void PartOne(Dictionary<string, int> registers, List<Operation> operations)
{
    Console.WriteLine($"Part One: Circuit output is {Run(registers, operations)}.\n");
}
void PartTwo(Dictionary<string, int> registers, List<Operation> operations)
{
    var swapped = GetResultRegisterData(new(registers), [.. operations]);
    var result = swapped.Order().Aggregate("", (a, b) => $"{a},{b}")[1..];

    Console.WriteLine($"Part One: Swapp wires: {result}.\n");
}

var (registers, operations) = Input.GetData();
PartOne(new(registers), operations.ToList());
PartTwo(new(registers), operations.ToList());