

using Day_8___Resonant_Collinearity;
using AdventLibrary;

void ProcessAntennaAntinodes(Matrix<bool> antinodeMap,int x, int y, int diff_x, int diff_y, bool considerResonanHarmonics)
{
    if (Math.Abs(diff_x) + Math.Abs(diff_y) > 0)
    {
        int current_x = x + diff_x;
        int current_y = y + diff_y;

        if (!considerResonanHarmonics )
        {
            if (antinodeMap.NotOutOfBounds(current_x, current_y))
            {
                antinodeMap[current_x, current_y] = true;
            }
        }
        else
        {
            while (antinodeMap.NotOutOfBounds(current_x, current_y))
            {
                antinodeMap[current_x, current_y] = true;

                current_x += diff_x;
                current_y += diff_y;
            }
        }
    }
    else if (considerResonanHarmonics)
    {
        antinodeMap[x, y] = true;
    }
}

void ProcessAntenna(Matrix<char> antennaMap, Matrix<bool> antinodeMap, int other_x, int other_y, bool considerResonanHarmonics)
{
    var antennasOfSameType = antennaMap.Where(cell => cell.value == antennaMap[other_x, other_y]);

    foreach ((int x, int y, char value) in antennasOfSameType)
    {
        int diff_x = other_x - x;
        int diff_y = other_y - y;

        ProcessAntennaAntinodes(antinodeMap, other_x, other_y, diff_x, diff_y, considerResonanHarmonics);
    }
}

int CountAntinodes(Matrix<char> antennaMap, bool considerResonanHarmonics)
{
    var antinodeMap = new Matrix<bool>(antennaMap.Width, antennaMap.Height);

    var antennas = antennaMap.Where(cell => cell.value != Input.NO_ANTENNA);

    foreach ((int x, int y, char value) in antennas)
    {
        ProcessAntenna(antennaMap, antinodeMap, x, y, considerResonanHarmonics);
    }

    Console.WriteLine(antinodeMap.ToString(cellValue => cellValue ? "#" : "."));

    return antinodeMap.Where(cell => cell.value).Count();
}

void PartOne(Matrix<char> antennaMap)
{
    Console.WriteLine($"Part one -- Number of antinodes are {CountAntinodes(antennaMap, false)}.\n");
}

void PartTwo(Matrix<char> antennaMap)
{
    Console.WriteLine($"Part two -- Number of antinodes when harmonics are considered are {CountAntinodes(antennaMap, true)}.");
}

var antennaMap = Input.GetData();
PartOne(antennaMap);
PartTwo(antennaMap);