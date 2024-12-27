using AdventLibrary;
using Day_21___Keypad_Conundrum;
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
string MovementToControlKeys(Matrix<char> matrix, Position movement, int depth)
{
    var xes = GetKey(movement.X, ["<", ">"]) + " ";
    var yes = GetKey(movement.Y, ["^", "v"]) + " ";

    if (depth == 1)
    {
        if (xes.Length > 1 && xes[0] == '<' &&
            yes.Length > 1 && yes[0] == '^')
        {
            return xes[0] + yes + xes[1..];
        }
        else
        {
            return yes + xes;
        }
    }
    else if (matrix.Height > 2)
    {
        return yes + xes;
    }
    else
    {

        return yes + xes;
    }
}
void PartOne(IEnumerable<string> codes)
{
    var keypad = new Matrix<char>(new char[,]
    {
        { '7', '4', '1', '#' },
        { '8', '5', '2', '0' },
        { '9', '6', '3', 'A' }
    });
    var controlpad = new Matrix<char>(new char[,]
    {
        { '#', '<', },
        { '^', 'v', },
        { 'A', '>', },
    });

    int compelxity = 0;

    foreach (var code in codes)
    {
        //
        // Robot one
        //
        var nrOfTotalSteps = code.Length;

        var currentCode = code;

        Matrix<char>[] inputDevices = [keypad, controlpad, controlpad];

        int depth = 0;

        foreach (var device in inputDevices)
        {
            var keyA = device.First(x => x.value == 'A');
            var position = new Position(keyA.x, keyA.y);

            var newCode = string.Empty;

            foreach (var c in currentCode)
            {
                var nextKeyPosition = device.First(x => x.value == c);
                var next = new Position(nextKeyPosition.x, nextKeyPosition.y);
                var localSteps = Matrix<char>.GetDistance(position, next);

                nrOfTotalSteps += localSteps;

                newCode += MovementToControlKeys(device, next - position, depth).Replace(" ", "");
                newCode += "A";

                position = next;
            }

            Console.WriteLine($"{code} requires {nrOfTotalSteps} key presses; {newCode}.");

            currentCode = newCode;

            depth++;
        }

        var codeValue = int.Parse(code[..^1]);
        compelxity += codeValue * nrOfTotalSteps;

        Console.WriteLine($"{codeValue} * {nrOfTotalSteps}.");
    }

    Console.WriteLine($"Part One: Sum of complexities is {compelxity}.\n");
}
void PartTwo(IEnumerable<string> codes)
{

}

var codes = Input.GetTrainingData();
PartOne(codes);
PartTwo(codes);