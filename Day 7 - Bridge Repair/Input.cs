namespace Day_7___Bridge_Repair
{
    internal class Input
    {
        static CalibrationEquation[] Parse(string filePath)
        {
            var value = File.ReadAllLines(filePath);
            return value.Select(x => new CalibrationEquation(x)).ToArray();
        }
        public static CalibrationEquation[] GetData()
        {
            return Parse(@"Data/Input.txt");
        }
        public static CalibrationEquation[] GetTrainingData()
        {
            return Parse(@"Data/TrainingInput.txt");
        }
    }
}
