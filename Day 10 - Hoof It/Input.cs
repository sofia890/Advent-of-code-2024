using AdventLibrary;

namespace Day_10___Hoof_It
{
    internal class Input
    {
        static Matrix<byte> ParseMatrix(string filePath)
        {
            string value = File.ReadAllText(filePath);
            string[] lines = value.Split("\r\n");

            int width = lines[0].Length;
            int height = lines.Length;
            var data = new byte[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    data[x, y] = byte.Parse(lines[y][x].ToString());
                }
            }

            return new Matrix<byte>(data);
        }

        public static Matrix<byte> GetData()
        {
            return ParseMatrix(@"Data/Input.txt");
        }

        public static Matrix<byte> GetTrainingData()
        {
            return ParseMatrix(@"Data/TrainingInput.txt");
        }
    }
}