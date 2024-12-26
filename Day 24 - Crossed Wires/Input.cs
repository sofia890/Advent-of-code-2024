using System.Diagnostics.CodeAnalysis;

namespace Day_24___Crossed_Wires
{
    internal class Operation(string _inA, string _action, string _inB, string _outA) : IEqualityComparer<Operation>
    {
        public string OutA
        {
            get;
            set;
        } = _outA;
        public bool IsReady(Dictionary<string, int> registers)
        {
            var isReadyInA = registers.ContainsKey(_inA);
            var isReadyInB = registers.ContainsKey(_inB);
            int valueInA = registers.GetValueOrDefault(_inA);
            int valueInB = registers.GetValueOrDefault(_inB);

            bool bothInReady = isReadyInA && isReadyInB;

            //return Action switch
            //{
            //    "AND" => bothInReady ||
            //             (isReadyInA && valueInA == 0) ||
            //             (isReadyInB && valueInB == 0),
            //    "OR" => bothInReady ||
            //            (isReadyInA && valueInA == 1) ||
            //            (isReadyInB && valueInB == 1),
            //    "XOR" => bothInReady,
            //    _ => throw new NotImplementedException()
            //};
            return bothInReady;
        }
        public (int value, string register) Perform(Dictionary<string, int> registers, bool verbose=false)
        {
            int valueInA = registers.GetValueOrDefault(_inA);
            int valueInB = registers.GetValueOrDefault(_inB);

            var value = _action switch
            {
                "AND" => valueInA & valueInB,
                "OR" => valueInA | valueInB,
                "XOR" => valueInA ^ valueInB,
                _ => throw new NotImplementedException()
            } & 1;

            if (verbose)
            {
                Console.WriteLine($"{valueInA} {_action} {valueInB} = {value} => {OutA}");
            }

            return (value, OutA);
        }
        public void Deconstruct(out string inA,
                                out string inB,
                                out string action,
                                out string outA)
        {
            inA = _inA;
            inB = _inB;
            action = _action;
            outA = OutA;
        }
        public bool Equals(Operation? x, Operation? y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            var (xInA, xInB, xAction, xOutA) = x;
            var (yInA, yInB, yAction, yOutA) = x;
            return xInA == yInA &&
                   xInB == yInB &&
                   xAction == yAction &&
                   xOutA == yOutA; ;
        }
        public int GetHashCode([DisallowNull] Operation obj)
        {
            return _inA.GetHashCode() ^
                   _inB.GetHashCode() ^
                   _action.GetHashCode() ^
                   OutA.GetHashCode();
        }
        public override string ToString()
        {
            return $"{_inA} {_action} {_inB} => {OutA}";
        }
        public Operation Copy()
        {
            return new(_inA, _action, _inB, OutA);
        }
    }
    internal record InputData(Dictionary<string, int> registers, List<Operation> operations);
    static internal class Input
    {
        static InputData Parser(string filePath)
        {
            Dictionary<string, int> registers = [];

            var parts = File.ReadAllText(filePath).Split("\r\n\r\n");
            var registersRaw = parts[0].Split("\r\n").Select(x => x.Split(": "));

            foreach (var value in registersRaw)
            {
                registers.Add(value[0], int.Parse(value[1]));
            }

            List<Operation> operations = [];

            var partTwo = parts[1].Split("\r\n");

            foreach (var value in partTwo)
            {
                var components = value.Split(" -> ");
                var outA = components[1];

                var operation = components[0].Split(' ');
                var inA = operation[0];
                var action = operation[1];
                var inB = operation[2];

                operations.Add(new(inA, action, inB, outA));
            }

            return new(registers, operations);
        }
        public static InputData GetData()
        {
            return Parser("Data/Input.txt");
        }
        public static InputData GetTrainingDataSmallA()
        {
            return Parser("Data/TrainingInputSmallA.txt");
        }
        public static InputData GetTrainingDataSmallB()
        {
            return Parser("Data/TrainingInputSmallB.txt");
        }
        public static InputData GetTrainingDataLarge()
        {
            return Parser("Data/TrainingInputLarge.txt");
        }
    }
}
