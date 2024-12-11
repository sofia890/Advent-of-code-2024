namespace Day_11___Plutonian_Pebbles
{
    internal class Input
    {
        static IEnumerable<long> ParseList(string input)
        {
            return input.Split(' ').Select(long.Parse);
        }
        public static  (IEnumerable<long> numbers, int iterationsPartA, int iterationsPartB) GetData()
        {
            return (ParseList("0 44 175060 3442 593 54398 9 8101095"), 25, 75);
        }
        public static (IEnumerable<long> numbers, int iterationsPartA, int iterationsPartB) GetTrainingData()
        {
            return (ParseList("125 17"), 6, 0);
        }
    }
}
