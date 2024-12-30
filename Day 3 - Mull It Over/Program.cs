
using Day_3___Mull_It_Over;
using System.Text.RegularExpressions;

void PartOne(string instructions)
{
    var pattern = Pattern.PartOneRegex();

    long sum = 0;

    foreach (Match match in pattern.Matches(instructions))
    {
        int valueA = int.Parse(match.Groups[1].Value);
        int valueB = int.Parse(match.Groups[2].Value);
        sum += valueA * valueB;
    }

    Console.WriteLine($"Part Two: Total is {sum}.");
}
void PartTwo(string instructions)
{
    var pattern = Pattern.PartTwoRegex();

    long sum = 0;
    bool multiplicationEnabled = true;

    foreach (Match match in pattern.Matches(instructions))
    {
        multiplicationEnabled = match.Groups[0].Value switch
        {
            "do()" => true,
            "don't()" => false,
            _ => multiplicationEnabled,
        };

        if (multiplicationEnabled && match.Groups[1].Value == "mul")
        {
            int valueA = int.Parse(match.Groups[2].Value);
            int valueB = int.Parse(match.Groups[3].Value);
            sum += valueA * valueB;
        }
    }

    Console.WriteLine($"Part Two: Total is {sum}.");
}

var instructions = Input.GetData();
PartOne(instructions);
PartTwo(instructions);