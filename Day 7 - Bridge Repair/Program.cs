
using Day_7___Bridge_Repair;

long HandlePart(CalibrationEquation[] equations, bool isPartOne)
{
    long total = 0;

    foreach (var item in equations)
    {
        if (item.BruteForce(isPartOne))
        {
            total += item.ExpectedValue;
        }
    }

    return total;
}
void PartOne(CalibrationEquation[] equations)
{
    Console.WriteLine($"Part One: Sum of all valid calibration results is {HandlePart(equations, false)}");
}
void PartTwo(CalibrationEquation[] equations)
{
    Console.WriteLine($"Part Two: Sum of all valid calibration results is {HandlePart(equations, true)}");
}

var data = Input.GetData();
PartOne(data);
PartTwo(data);