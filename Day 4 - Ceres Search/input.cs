namespace Day_4___Ceres_Search
{
    public static class Input
    {
        public static string[] GetData()
        {
            return File.ReadAllLines("Data/Input.txt");
        }

        public static string[] GetTrainingData()
        {
            return File.ReadAllLines("Data/TrainingInput.txt");
        }
    }
}
