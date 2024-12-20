using AdventLibrary;

using TestInput = (AdventLibrary.Matrix<char> matrix, int nrOfCheatStepsA, int nrOfCheatStepsB, int minSavedStepsA, int minSavedStepsB);

namespace Day_20___Race_Condition
{
    static internal class Input
    {
        const int N_CHEAT_STEPS_A = 2;
        const int N_CHEAT_STEPS_B = 20;
        static TestInput Parser(string filePath, int minSavedStepsA, int minSavedStepsB)
        {
            return (MatrixParser.Parse(File.ReadAllText(filePath)), N_CHEAT_STEPS_A, N_CHEAT_STEPS_B, minSavedStepsA, minSavedStepsB);
        }
        public static TestInput GetData()
        {
            return Parser("Data/Input.txt", 100, 100);
        }
        public static TestInput GetTrainingData()
        {
            return Parser("Data/TrainingInput.txt", 1, 50);
        }
    }
}
