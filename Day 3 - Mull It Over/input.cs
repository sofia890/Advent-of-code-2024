namespace Day_3___Mull_It_Over
{
    public static class Input
    {
        static string ReadData(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        public static string GetData()
        {
            return ReadData(@"Data/Input.txt");
        }
        public static string GeTrainingDataPartOne()
        {
            return ReadData(@"Data/TrainingInputPartOne.txt");
        }
        public static string GeTrainingDataPartTwo()
        {
            return ReadData(@"Data/TrainingInputPartTwo.txt");
        }
    }
}
