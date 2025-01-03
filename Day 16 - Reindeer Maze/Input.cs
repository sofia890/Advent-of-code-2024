using AdventLibrary;

namespace Day_16___Reindeer_Maze
{
    internal class Input
    {
        static Matrix<char> Parse(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int height = lines.Length;
            int width = lines[0].Length;

            var data = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Want X-axis to be first dimension.
                    data[j, i] = lines[i][j];
                }
            }

            return new(data);
        }
        public static Matrix<char> GetData()
        {
            return Parse("Data/Input.txt");
        }
        public static Matrix<char> GetTrainingData()
        {
            return Parse("Data/TrainingInput.txt");
        }
    }
}
