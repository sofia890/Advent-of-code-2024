namespace Day_19___Linen_Layout
{
    internal class Input
    {
        static (string[] towels, string[] patterns) Parse(string value)
        {
            var parts = value.Split("\r\n\r\n");
            return (parts[0].Split(", "), parts[1].Split("\r\n"));
        }
        public static (string[] towels, string[] patterns) GetData()
        {
            return Parse(File.ReadAllText("Data/Input.txt"));
        }
        public static (string[] towels, string[] patterns) GetTrainingData()
        {
            return Parse(File.ReadAllText("Data/TrainingInput.txt"));
        }
    }
}
