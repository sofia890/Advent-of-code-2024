namespace Day_2___Red_Nosed_Reports
{
    internal static class Input
    {
        static List<int[]> Parse(string filePath)
        {
            return File.ReadAllText(filePath)
                       .Split("\r\n")
                       .Select(x => x.Split(' ')
                                     .Select(int.Parse)
                                     .ToArray())
                       .ToList();
        }
        public static List<int[]> GetData()
        {
            return Parse("Data/Input.txt");
        }
        public static List<int[]> GetTrainingData()
        {
            return Parse("Data/TrainingInput.txt");
        }
    }
}
