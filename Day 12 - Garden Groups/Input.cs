using AdventLibrary;

namespace Day_12___Garden_Groups
{
    internal class Input
    {
        private static Matrix<char> Parse(string filePath)
        {
            string data = File.ReadAllText(filePath);

            return MatrixParser.Parse(data);
        }
        public static Matrix<char> GetData()
        {
            return Parse(@"Data/Input.txt");
        }
        public static Matrix<char> GetTrainingDataPartOne()
        {
            return Parse(@"Data/TrainingInputPartOne.txt");
        }
        public static Matrix<char> GetTrainingDataPartTwo()
        {
            return Parse(@"Data/TrainingInputPartTwo.txt");
        }
    }
}
