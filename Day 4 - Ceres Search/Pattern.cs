using System.Text.RegularExpressions;

namespace Day_4___Ceres_Search
{
    partial class Pattern
    {
        [GeneratedRegex(@"(?<=X)MA(?=S)|(?<=S)AM(?=X)")]
        public static partial Regex PartOneXmas();

        [GeneratedRegex(@"SAM|MAS")]
        public static partial Regex PartTwoMas();
    }
}
