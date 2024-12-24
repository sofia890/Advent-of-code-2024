namespace Day_22___Monkey_Market
{
    static internal class Input
    {
        static IEnumerable<int> Parser(string filePath)
        {
            return File.ReadAllText(filePath).Split("\r\n").Select(int.Parse);
        }
        public static (IEnumerable<int> seeds, int steps) GetData()
        {
            return (Parser("Data/Input.txt"), 2000);
        }
        public static (IEnumerable<int> seeds, int steps) GetTrainingDataA()
        {
            return (Parser("Data/TrainingInputA.txt"), 2000);
        }
        public static (IEnumerable<int> seeds, int steps) GetTrainingDataB()
        {
            return (Parser("Data/TrainingInputB.txt"), 2000);
        }
    }
}
