namespace Day_23___LAN_Party
{
    internal record Connection(string NodeA, string NodeB);
    internal static class Input
    {
        static (Connection[] connections, string prefix) Parser(string filePath)
        {
            var connections = File.ReadAllText(filePath)
                                  .Split("\r\n")
                                  .Select(x =>
                                  {
                                      var components = x.Split("-").Order();
                                      return new Connection(components.First(), components.Last());
                                  })
                                  .DistinctBy(x => $"{x.NodeA}{x.NodeB}");

            return (connections.ToArray(), "t");
        }
        public static (Connection[] connections, string prefix) GetData()
        {
            return Parser("Data/Input.txt");
        }
        public static (Connection[] connections, string prefix) GetTrainingData()
        {
            return Parser("Data/TrainingInput.txt");
        }
    }
}
