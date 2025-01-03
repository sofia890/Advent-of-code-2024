namespace Day_6___Guard_Gallivant
{
    public static class Input
    {
        private static TileTypes[,] ToMatrix(string filePath)
        {
            string data = File.ReadAllText(filePath);
            string[] lines = data.Split("\r\n");
            int height = lines.Length;
            int width = lines[0].Length;

            var matrix = new TileTypes[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Want X-axis to be first dimension.
                    matrix[j, i] = (TileTypes)lines[i][j];
                }
            }

            return matrix;
        }

        public static TileTypes[,] GetData()
        {
            return ToMatrix(@"Data/Input.txt");
        }

        public static TileTypes[,] GeTrainingData()
        {
            return ToMatrix(@"Data/TrainingInput.txt");
        }
    }
}
