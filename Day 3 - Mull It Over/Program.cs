
using Day_3___Mull_It_Over;
using System.Text.RegularExpressions;

//
// Part one
//
var patternPartOne = new Regex(@"mul\((\d{1,3}),[ ]*(\d{1,3})\)");

long sumPartOne = 0;

foreach (Match match in patternPartOne.Matches(Input.GetData()))
{
    int valueA = int.Parse(match.Groups[1].Value);
    int valueB = int.Parse(match.Groups[2].Value);
    sumPartOne += valueA * valueB;
}

Console.WriteLine($"Part One Total: {sumPartOne}");

//
// Part Two
//
var patternPartTwo = new Regex(@"(mul)\((\d{1,3}),[ ]*(\d{1,3})\)|do\(\)|don\'t\(\)");

long sumPartTwo = 0;
bool multiplicationEnabled = true;

foreach (Match match in patternPartTwo.Matches(Input.GetData()))
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
        sumPartTwo += valueA * valueB;
    }
}

Console.WriteLine($"Part Two Total: {sumPartTwo}");