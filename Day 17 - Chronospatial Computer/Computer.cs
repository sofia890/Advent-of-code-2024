using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_17___Chronospatial_Computer
{
    internal enum Optcode
    {
        DivisionToA_ACo,
        BitwiseXorToB_BL,
        ModuloEightToB,
        ConditionalJumpBasedOnA,
        BitwiseXorToB_BC,
        OutputModuloEight_Co,
        DivisionToB_ACo,
        DivisionToC_ACo,
    }
    internal enum Combo
    {
        Zero,
        One,
        Two,
        Three,
        RegisterA,
        RegisterB,
        RegisterC,
        Reserved
    }
    internal class Computer
    {
        private int RegisterA
        {
            get;
            set;
        }
        private int RegisterB
        {
            get;
            set;
        }
        private int RegisterC
        {
            get;
            set;
        }
        private int[] Program
        {
            get;
            set;
        }
        public Computer(int[] program, int reigsterA, int registerB, int registerC)
        {
            Program = program;
            RegisterA = reigsterA;
            RegisterB = registerB;
            RegisterC = registerC;
        }
        int ResolveComboOperand(Combo value)
        {
            return value switch
            {
                Combo.Zero => 0,
                Combo.One => 1,
                Combo.Two => 2,
                Combo.Three => 3,
                Combo.RegisterA => RegisterA,
                Combo.RegisterB => RegisterB,
                Combo.RegisterC => RegisterC,
                Combo.Reserved => throw new InvalidOperationException(),
                _ => throw new NotImplementedException(),
            };
        }
        public List<int> Run()
        {
            var output = new List<int>();

            for (int instructionPointer = 0; instructionPointer < Program.Length; instructionPointer += 2)
            {
                var optcode = (Optcode)Program[instructionPointer];
                var literalOperand = Program[instructionPointer + 1];
                var comboOperand = ResolveComboOperand((Combo)literalOperand);

                switch (optcode)
                {
                    case Optcode.DivisionToA_ACo:
                        RegisterA = RegisterA / (int)Math.Pow(2, comboOperand);
                        break;

                    case Optcode.BitwiseXorToB_BL:
                        RegisterB = RegisterB ^ literalOperand;
                        break;

                    case Optcode.ModuloEightToB:
                        RegisterB = comboOperand % 8;
                        break;

                    case Optcode.ConditionalJumpBasedOnA:
                        if (RegisterA != 0)
                        {
                            // Adjust for the increment in the for loop
                            instructionPointer = literalOperand - 2;
                        }
                        break;

                    case Optcode.BitwiseXorToB_BC:
                        RegisterB = RegisterB ^ RegisterC;
                        break;

                    case Optcode.OutputModuloEight_Co:
                        output.Add(comboOperand % 8);
                        break;

                    case Optcode.DivisionToB_ACo:
                        RegisterB = RegisterA / (int)Math.Pow(2, comboOperand);
                        break;

                    case Optcode.DivisionToC_ACo:
                        RegisterC = RegisterA / (int)Math.Pow(2, comboOperand);
                        break;
                }
            }

            return output;
        }

        private IEnumerable<(int a, int lastOptcode)> GetReverseSeeds()
        {
            for (int i = 0; i <= (Math.Pow(2, 11) - 1); i++)
            {
                int registerA = i;

                int registerB = registerA % 8;
                registerB = registerB ^ 3;
                int registerC = registerA >> registerB;
                registerB = registerB ^ registerC;
                registerB = registerB ^ 5;

                var output = registerB % 8;

                if (output == Program[Program.Length - 1])
                {
                    yield return (registerA, output);
                }
            }
        }

        public int ReverseRun()
        {
            var matches = new List<long>();

            foreach ((int a, int lastOptcode) in GetReverseSeeds())
            {
                var newProgram = $"{lastOptcode}";

                var workQueue = new Queue<(int index, long registerA)>();
                workQueue.Enqueue((Program.Length - 2, a));

                while (workQueue.Any())
                {
                    var (index, currentRegisterA) = workQueue.Dequeue();
                    long registerA = currentRegisterA << 3;

                    for (long j = 0; j <= (Math.Pow(2, 3) - 1); j++)
                    {
                        long tempRegisterA = registerA | j;
                        long registerB = tempRegisterA % 8;
                        registerB = registerB ^ 3;
                        long registerC = tempRegisterA >> (int)registerB;
                        registerB = registerB ^ registerC;
                        registerB = registerB ^ 5;

                        long output = registerB % 8;

                        if (Program[index] == output)
                        {
                            if (index == 0)
                            {
                                matches.Add(tempRegisterA);
                            }
                            else if (index > 0)
                            {
                                workQueue.Enqueue((index - 1, tempRegisterA));
                            }
                        }
                    }
                }
            }

            var validRegisterValues = matches.Order()
                                             .Select(x => x.ToString())
                                             .Aggregate("", (a, b) => $"{a}, {b}");

            Console.WriteLine($"Part Two: Register A values that cause the program to output itself are: {validRegisterValues[1..]}.\n");
            return 1;
        }
    }
}
