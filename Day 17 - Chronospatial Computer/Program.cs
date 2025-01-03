using Day_17___Chronospatial_Computer;

void PartOne(int[] program, int reigisterA, int reigisterB, int reigisterC)
{
    var computer = new Computer(program, reigisterA, reigisterB, reigisterC);
    var output = computer.Run().Aggregate("", (a, b) => $"{a},{b}")[1..];

    Console.WriteLine($"Part One: Program output is {output}.\n");
}
void PartTwo(int[] program)
{
    var computer = new Computer(program, 0, 0, 0);

    Console.WriteLine("Part Two: Smallest register A values that " +
        $"cause the program to output itself are: {computer.ReverseRun()}.\n");
}

(var program, var reigisterA, var registerB, var registerC) = Input.GetData();
PartOne(program, reigisterA, registerB, registerC);
PartTwo(program);