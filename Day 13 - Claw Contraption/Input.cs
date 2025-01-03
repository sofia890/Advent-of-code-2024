using AdventLibrary;

namespace Day_13___Claw_Contraption
{
    internal class Input
    {
        const int LINES_PER_ENTRY = 3;
        public record Position(long X, long Y);
        public record StepSize(long X, long Y);
        public record Entry(Position Goal, StepSize A, StepSize B);

        static List<Entry> Parse(string filePath)
        {
            var list = new List<Entry>();
            var data = File.ReadAllText(filePath);

            var machines = data.Replace("\r\n\r\n", "\r\n")
                               .Split("\r\n")
                               .Select((value, index) => (value, index))
                               .GroupBy(x => x.index / LINES_PER_ENTRY)
                               .Select(x =>
                                 x.Select(y => y.value)
                                  .ToArray()
                               );

            foreach (string[] lines in machines)
            {
                var movmentA = Parser.ToIntegerArray<long>(lines[0][10..], 1);
                var movementB = Parser.ToIntegerArray<long>(lines[1][10..], 1);
                var goal = Parser.ToIntegerArray<long>(lines[2][7..], 2);

                list.Add(new Entry(new Position(goal[0], goal[1]),
                                   new StepSize(movmentA[0], movmentA[1]),
                                   new StepSize(movementB[0], movementB[1])));
            }

            return list;
        }

        public static IEnumerable<Entry> GetData()
        {
            return Parse(@"Data/Input.txt");
        }

        public static IEnumerable<Entry> GetTrainingData()
        {
            return Parse(@"Data/TrainingInput.txt");
        }
    }
}
