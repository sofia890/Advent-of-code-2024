namespace Day_17___Chronospatial_Computer
{
    internal static class Input
    {
        private static (int[] opcodes, int a, int b, int c) Parse(string filePath, int a)
        {
            string data = File.ReadAllText(filePath);
            var stoneNumbers = data.Split(',').Select(int.Parse).ToArray();

            return (stoneNumbers, a, 0, 0);
        }

        public static (int[] opcodes, int a, int b, int c) GetData()
        {
            return Parse("Data/Input.txt", 45483412);
        }

        public static (int[] opcodes, int a, int b, int c) GetTrainingData()
        {
            return Parse("Data/TrainingInput.txt", 729);
        }
    }
}
