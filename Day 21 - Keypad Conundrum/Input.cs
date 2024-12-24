namespace Day_21___Keypad_Conundrum
{
    static internal class Input
    {
        static IEnumerable<string> Parser(string filePath)
        {
            return File.ReadAllText(filePath).Split("\r\n");
        }
        public static IEnumerable<string> GetData()
        {
            return Parser("Data/Input.txt");
        }
        public static IEnumerable<string> GetTrainingData()
        {
            return Parser("Data/TrainingInput.txt");
        }
    }
}
