using AdventLibrary;

namespace Day_25___Code_Chronicle
{
    internal record InputData(List<int[]> Keys, List<int[]> Locks, int Height);
    static internal class Input
    {
        static InputData Parser(string filePath)
        {
            List<int[]> keys = [];
            List<int[]> locks = [];
            int height = 0;

            var entries = File.ReadAllText(filePath).Split("\r\n\r\n");

            foreach (var entry in entries)
            {
                const char SHAPE = '#';

                var matrix = new Matrix<char>(entry);

                height = matrix.Height;

                var isLock = matrix.AsRows()
                                   .First()
                                   .Count(x => x.value == SHAPE)
                                   .Equals(matrix.Width);

                var columnHeights = matrix.AsColumns()
                                          .Select(x => x.Count(y => y.value == SHAPE) - 1)
                                          .ToArray();

                if (isLock)
                {
                    locks.Add(columnHeights);
                }
                else
                {
                    keys.Add(columnHeights);
                }
            }

            // The top and bottom rows are used to identify if the entry is a lock or key.
            const int N_RESERVED_ROWS = 2;

            return new(keys, locks, height - N_RESERVED_ROWS);
        }
        public static InputData GetData()
        {
            return Parser("Data/Input.txt");
        }
        public static InputData GetTrainingData()
        {
            return Parser("Data/TrainingInput.txt");
        }
    }
}
