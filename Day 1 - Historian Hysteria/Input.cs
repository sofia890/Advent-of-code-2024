namespace Day_1___Historian_Hysteria
{
    internal class Input
    {
        static List<int>[] Parse(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            List<int>[] result = [[], []];

            foreach (var line in lines)
            {
                var parts = line.Split("   ");
                result[0].Add(int.Parse(parts[0]));
                result[1].Add(int.Parse(parts[1]));
            }

            return result;
        }

        public static List<int>[] GetData()
        {
            return Parse(@"Data/Input.txt");
        }

        public static List<int>[] GetTrainingData()
        {
            return Parse(@"Data/TrainingInput.txt");
        }
    }
}
