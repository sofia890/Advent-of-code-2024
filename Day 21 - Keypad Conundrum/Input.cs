namespace Day_21___Keypad_Conundrum
{
    internal record InputData(IEnumerable<string> Codes, int NrOfKeypadsPartOne, int NrOfKeypadsPartTwo);
    static internal class Input
    {
        static InputData Parser(string filePath)
        {
            return new(File.ReadAllText(filePath).Split("\r\n"), 3, 26);
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
