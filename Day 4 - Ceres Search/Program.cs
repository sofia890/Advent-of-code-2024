using Day_4___Ceres_Search;
using System.Text.RegularExpressions;

//
// Part one
//
const string PATH_SEPARATOR = "\n";

var data = Input.GetData();

string combined_paths = "";

// Horizontal paths
for (int row = 0; row < data.Length; row++)
{
    combined_paths += data[row] + PATH_SEPARATOR;
}

// Vertical paths
for (int column = 0; column < data[0].Length; column++)
{
    string path = "";

    for (int row = 0; row < data.Length; row++)
    {
        path += data[row][column];
    }

    combined_paths += path + PATH_SEPARATOR;
}

// Diagonal \, first row paths
for (int current_char = 0; current_char < data[0].Length; current_char++)
{
    string path = "";

    int row = 0;
    int column = current_char;

    while (row < data.Length && column < data[0].Length)
    {
        path += data[row][column];

        row++;
        column++;
    }

    combined_paths += path + PATH_SEPARATOR;
}

// Diagonal \, remaining rows paths
for (int row = 1; row < data[0].Length; row++)
{
    string path = "";

    int current_row = row;
    int current_column = 0;

    while (current_row < data.Length && current_column < data[0].Length)
    {
        path += data[current_row][current_column];

        current_row++;
        current_column++;
    }

    combined_paths += path + PATH_SEPARATOR;
}

// Diagonal /, first row paths
for (int current_char = data[0].Length - 1; 0 <= current_char; current_char--)
{
    string path = "";

    int row = 0;
    int column = current_char;

    while (row < data.Length && 0 <= column)
    {
        path += data[row][column];

        row++;
        column--;
    }

    combined_paths += path + PATH_SEPARATOR;
}

// Diagonal /, remaining rows paths
for (int row = 1; row < data[0].Length; row++)
{
    string path = "";

    int current_row = row;
    int current_column = data[0].Length - 1;

    while (current_row < data.Length && 0 <= current_column)
    {
        path += data[current_row][current_column];

        current_row++;
        current_column--;
    }

    combined_paths += path + PATH_SEPARATOR;
}

var pattern_part_one = new Regex(@"(?<=X)MA(?=S)|(?<=S)AM(?=X)");

Console.WriteLine($"Part One -- Number of matches of XMAS and SAMX are {pattern_part_one.Count(combined_paths)}.");

//
// Part Two
//
const int MATCH_WIDTH = 3;
const int MATCH_HEIGHT = 3;

var pattern_part_two = new Regex(@"SAM|MAS");

bool isMatch(string[] matrix, int origin_row, int origin_column)
{
    if (origin_row + MATCH_HEIGHT - 1 >= matrix.Length)
    {
        return false;
    }
    else if (origin_column + MATCH_WIDTH - 1 >= matrix[0].Length)
    {
        return false;
    }

    string path_a = $"{matrix[origin_row][origin_column]}{matrix[origin_row + 1][origin_column + 1]}{matrix[origin_row + 2][origin_column + 2]}";
    string path_b = $"{matrix[origin_row][origin_column + 2]}{matrix[origin_row + 1][origin_column + 1]}{matrix[origin_row + 2][origin_column]}";
    string cross_combined_paths = $"{path_a}{PATH_SEPARATOR}{path_b}";

    return pattern_part_two.Count(cross_combined_paths) == 2;
}

int nrof_of_matches_part_two = 0;

for (int row = 0; row < data.Length; row++)
{
    for (int column = 0; column < data[0].Length; column++)
    {
        if (isMatch(data, row, column))
        {
            nrof_of_matches_part_two++;
        }
    }
}

Console.WriteLine($"Part Two -- Number of matches of crosses {nrof_of_matches_part_two}.");