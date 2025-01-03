using AdventLibrary;

namespace Day_8___Resonant_Collinearity
{
    internal class Input
    {
        public const char NO_ANTENNA = '.';
        public static Matrix<char> GetData(string filePath)
        {
            var data = File.ReadAllText(filePath);

            return MatrixParser.Parse(data);
        }
        public static Matrix<char> GetData()
        {
            return GetData(@"Data/Input.txt");
        }
        public static Matrix<char> GetTrainingDataPartOne()
        {
            return GetData(@"Data/TrainingInputPartOne.txt");
        }
        public static Matrix<char> GetTrainingDataPartTwo()
        {
            return GetData(@"Data/TrainingInputPartTwo.txt");
        }
    }
}
