using Day_17___Chronospatial_Computer;

void PartOne(int[] program, int reigisterA, int reigisterB, int reigisterC)
{
    var computer = new Computer(program, reigisterA, reigisterB, reigisterC);
    var output = computer.Run().Aggregate("", (a, b) => $"{a},{b}");

    Console.WriteLine($"Part One: Program output is {output}.\n");
}
void PartTwo(int[] program)
{
    var computer = new Computer(program, 0, 0, 0);
    computer.ReverseRun();

    //int reigisterA = 0;
    //var output = new List<int>();

    //while (program.Length != output.Count ||
    //       Enumerable.Range(0, program.Length)
    //                 .Any(x => program[x] != output[x]))
    //{
    //    if (reigisterA % 100000 == 0)
    //    {
    //        Console.WriteLine($"Iteration: {reigisterA}");
    //    }

    //    var computer = new Computer(program, reigisterA++, 0, 0);
    //    output = computer.Run();
    //}

    //Console.WriteLine($"Part Two: Program outputs itself when register A is {reigisterA}.\n");
}

(var program, var reigisterA, var registerB, var registerC) = Input.GetData();
PartOne(program, reigisterA, registerB, registerC);
PartTwo(program);