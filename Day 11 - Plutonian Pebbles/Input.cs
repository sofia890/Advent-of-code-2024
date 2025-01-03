namespace Day_11___Plutonian_Pebbles
{
    internal class Input
    {
        static IEnumerable<long> Parse(string filePath)
        {
            var input = File.ReadAllText(filePath);

            return input.Split(' ').Select(long.Parse);
        }

        public static (IEnumerable<long> numbers, int iterationsPartA, int iterationsPartB) GetData()
        {
            return (Parse(@"Data/Input.txt"), 25, 75);
        }

        public static (IEnumerable<long> numbers, int iterationsPartA, int iterationsPartB) GetTrainingData()
        {
            return (Parse(@"Data/TrainingInput.txt"), 6, 0);
        }
    }
}
