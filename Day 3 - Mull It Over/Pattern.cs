using System.Text.RegularExpressions;

namespace Day_3___Mull_It_Over
{
    partial class Pattern
    {
        [GeneratedRegex(@"mul\((\d{1,3}),[ ]*(\d{1,3})\)")]
        public static partial Regex PartOneRegex();

        [GeneratedRegex(@"(mul)\((\d{1,3}),[ ]*(\d{1,3})\)|do\(\)|don\'t\(\)")]
        public static partial Regex PartTwoRegex();
    }
}