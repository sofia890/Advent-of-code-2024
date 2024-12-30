using AdventLibrary;
using Day_21___Keypad_Conundrum;

const char START_SYMBOL = 'A';

string GetKey(int value, string[] controlKeys)
{
    var keys = "";
    var horozontalKey = "";

    if (value == 0)
    {
        return "";
    }

    if (value < 0)
    {
        horozontalKey = controlKeys[0];
    }
    else if (value > 0)
    {
        horozontalKey = controlKeys[1];
    }

    for (int i = 0; i < Math.Abs(value); i++)
    {
        keys += horozontalKey;
    }

    return keys;
}
string MovementToControlKeys(Matrix<char> matrix, Position movement, Pad pad)
{
    var horizontalPreses = GetKey(movement.X, ["<", ">"]);
    var verticalPresses = GetKey(movement.Y, ["^", "v"]);

    string preferredPath;
    string backupPath;

    var alternativeA = horizontalPreses + verticalPresses;
    var alternativeB = verticalPresses + horizontalPreses;

    if (horizontalPreses.Length > 0 &&
        horizontalPreses[0] == '<' &&
        verticalPresses.Length > 0)
    {
        preferredPath = alternativeA;
        backupPath = alternativeB;
    }
    else
    {
        preferredPath = alternativeB;
        backupPath = alternativeA;
    }

    foreach (var c in preferredPath)
    {
        if (!pad.TryInput(c))
        {
            return backupPath;
        }
    }

    return preferredPath;
}
EventHandler<char> CreatePadKeyHandeler(Pad[] devices, string[] outputs, int deviceIndex)
{
    return (sender, input) =>
    {
        outputs[deviceIndex] += input;

        int nextIndex = deviceIndex + 1;

        if (nextIndex < devices.Length)
        {
            _ = devices[nextIndex].Input(input);
        }
    };
}
void DisplayAndVerify(
    string expectedOutput,
    string input,
    int refreshRate,
    int nrOfPads,
    bool verbose)
{
    var outputs = Enumerable.Repeat("", nrOfPads + 1).ToArray();

    var numpad = new Numpad();
    var keypads = Enumerable.Range(0, nrOfPads).Select(x => new KeyPad());
    Pad[] devices = [numpad, .. keypads];

    for (int i = 0; i < devices.Length; i++)
    {
        devices[i].KeyPressed += CreatePadKeyHandeler(devices, outputs, i);
    }

    if (verbose)
    {
        Console.WriteLine();
        Console.WriteLine($"== Playback level {nrOfPads:2} ========================");
    }

    var (originLeft, originTop) = Console.GetCursorPosition();

    foreach (var c in input)
    {
        outputs[^1] += c;

        _ = devices[^1].Input(c);

        if (!verbose)
        {
            continue;
        }

        Console.SetCursorPosition(originLeft, originTop);
        Console.WriteLine($"Actions: {input}");

        for (int i = devices.Length - 1; i > 0; i++)
        {
            Console.WriteLine($"       : {outputs[i]}");
        }

        Console.WriteLine();
        Console.WriteLine($"Output : {expectedOutput}");
        Console.WriteLine($"       : {outputs[0]}");

        foreach (var device in devices)
        {
            Console.WriteLine();
            Console.WriteLine(device.ToString());
        }

        if (!expectedOutput.StartsWith(outputs[0]))
        {
            throw new Exception($"Entered code ({outputs[0]}) does not match expected code ({expectedOutput})!");
        }

        Console.WriteLine("=============================================");

        Thread.Sleep(refreshRate);
    }
}
(List<KeyToProcess> items, long steps) ProcessWorkQueueItem(
    KeyToProcess current,
    Matrix<char>[] keyMatrices,
    Pad[] inputDevices)
{
    var pad = inputDevices[current.DeviceIndex];
    pad.Set(current.PadInputIsOn.Copy());

    var device = keyMatrices[current.DeviceIndex];
    var next = new Position(device.First(x => x.value == current.Input));
    var movement = next - current.PadInputIsOn;

    string keys = MovementToControlKeys(keyMatrices[current.DeviceIndex + 1], movement, pad);
    var newKeysToPress = $"{keys}A";

    if ((current.DeviceIndex + 1) < (inputDevices.Length - 1))
    {
        List<KeyToProcess> nextKeys = [];

        var nextDeviceIndex = current.DeviceIndex + 1;
        var nextDevice = keyMatrices[nextDeviceIndex];

        var newStartPosition = nextDevice.First(x => x.value == START_SYMBOL);
        nextKeys.Add(new(newKeysToPress[0], nextDeviceIndex, new(newStartPosition), current.Count));

        for (int i = 1; i < newKeysToPress.Length; i++)
        {
            newStartPosition = nextDevice.First(x => x.value == newKeysToPress[i - 1]);

            nextKeys.Add(new(newKeysToPress[i], nextDeviceIndex, new(newStartPosition), current.Count));
        }

        return (nextKeys, 0L);
    }
    else
    {
        return ([], newKeysToPress.Length * current.Count);
    }
}
long GetCompelxityForCode(string code, int nrOfKeypads)
{
    //
    // Scenario to item mapping
    //
    Dictionary<(char input, Position position, int deviceIndex), KeyToProcess> scenarioToItem = [];

    //
    // Seed work queue with key presses
    //
    var numpad = new Matrix<char>(new char[,]
    {
        { '7', '4', '1', '#' },
        { '8', '5', '2', '0' },
        { '9', '6', '3', 'A' }
    });

    var startCell = numpad.First(x => x.value == START_SYMBOL);
    var startPosition = new Position(startCell.x, startCell.y);

    Queue<KeyToProcess> workQueue = new();

    foreach (var key in code)
    {
        var item = new KeyToProcess(key, 0, startPosition, 1);
        scenarioToItem.Add(item.GetIdentity(), item);
        workQueue.Enqueue(item);

        startCell = numpad.First(x => x.value == key);
        startPosition = new Position(startCell.x, startCell.y);
    }

    //
    // Encode key presses
    //
    var controlpad = new Matrix<char>(new char[,]
    {
        { '#', '<', },
        { '^', 'v', },
        { 'A', '>', },
    });

    Matrix<char>[] inputDevices = [numpad, .. Enumerable.Repeat(controlpad, nrOfKeypads)];
    Pad[] inputDevicePads = [new Numpad(), .. Enumerable.Repeat(new KeyPad(), nrOfKeypads)];

    long nrOfTotalSteps = 0L;

    while (workQueue.Count > 0)
    {
        var current = workQueue.Dequeue();
        var (items, nrOfSteps) = ProcessWorkQueueItem(current, inputDevices, inputDevicePads);

        nrOfTotalSteps += nrOfSteps;

        List<KeyToProcess> remainder = [];

        foreach (var item in items)
        {
            if (scenarioToItem.ContainsKey(item.GetIdentity()))
            {
                scenarioToItem[item.GetIdentity()].Count += item.Count;
            }
            else
            {
                scenarioToItem.Add(item.GetIdentity(), item);
                remainder.Add(item);
            }
        }

        foreach (var item in remainder)
        {
            workQueue.Enqueue(item);
        }
    }

    //
    // Calculate complexity
    //
    var codeValue = long.Parse(code[..^1]);
    return codeValue * nrOfTotalSteps;
}
long CalculateComplexitySum(IEnumerable<string> codes, int nrOfKeypads)
{
    return codes.AsParallel()
                .Select(x => GetCompelxityForCode(x, nrOfKeypads))
                .Aggregate(0L, (a, b) => a + b);
}
void Perform(IEnumerable<string> codes, int nrOfKeypads, string part)
{
    var compelxity = CalculateComplexitySum(codes, nrOfKeypads);
    Console.WriteLine($"Part {part}: Sum of complexities is {compelxity} for {nrOfKeypads} kepads.\n");
}

var (codes, nrOfKeypadsPartOne, nrOfKeypadsPartTwo) = Input.GetData();
Perform(codes, nrOfKeypadsPartOne, "One");
Perform(codes, nrOfKeypadsPartTwo, "Two");
