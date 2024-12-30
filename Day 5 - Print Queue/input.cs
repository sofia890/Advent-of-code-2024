using System.Buffers;

namespace Day_5___Print_Queue
{
    public static class Input
    {
        static (List<int[]>, List<int[]>) Parse(string filePath)
        {
            var parts = File.ReadAllText(filePath)
                            .Split("\r\n\r\n");
            var pairs = parts[0].Split("\r\n")
                                .Select(x => x.Split('|')
                                .Select(int.Parse)
                                .ToArray())
                                .ToList();
            var sequences = parts[1].Split("\r\n")
                                    .Select(x => x.Split(',')
                                                  .Select(int.Parse)
                                                  .ToArray())
                                    .ToList();

            return (pairs, sequences);
        }
        public static (List<int[]>, List<int[]>) GetData()
        {
            return Parse("Data/Input.txt");
        }
        public static (List<int[]>, List<int[]>) GetTrainingData()
        {
            return Parse("Data/TrainingInput.txt");
        }
    }
}
