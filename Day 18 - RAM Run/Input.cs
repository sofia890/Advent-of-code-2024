using AdventLibrary;

namespace Day_18___RAM_Run
{
    internal static class Input
    {
        private static IList<Position> Parse(string value)
        {
            var list = new List<Position>();

            return value.Split("\r\n")
                        .Select(line =>
                        {
                            var components = Parser.ToIntegerArray<int>(line, splitOn: ",");

                            return new Position(components[0], components[1]);
                        })
                        .ToList();
        }
        public static (IList<Position> bytes, int width, int height, int nrofFallenBytes) GetData()
        {
            var data = File.ReadAllText("Data/Input.txt");
            return (Parse(data), 71, 71, 1024);
        }
        public static (IList<Position> bytes, int width, int height, int nrofFallenBytes) GetTrainingData()
        {
            var data = File.ReadAllText("Data/TrainingInput.txt");
            return (Parse(data), 7, 7, 12);
        }
    }
}
