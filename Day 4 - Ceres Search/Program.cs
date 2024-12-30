﻿using Day_4___Ceres_Search;

//
// Part one
//
const string PATH_SEPARATOR = "\n";

var data = Input.GetData();

string combinedPaths = "";

// Horizontal paths
for (int row = 0; row < data.Length; row++)
{
    combinedPaths += data[row] + PATH_SEPARATOR;
}

// Vertical paths
for (int column = 0; column < data[0].Length; column++)
{
    string path = "";

    for (int row = 0; row < data.Length; row++)
    {
        path += data[row][column];
    }

    combinedPaths += path + PATH_SEPARATOR;
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

    combinedPaths += path + PATH_SEPARATOR;
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

    combinedPaths += path + PATH_SEPARATOR;
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

    combinedPaths += path + PATH_SEPARATOR;
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

    combinedPaths += path + PATH_SEPARATOR;
}

var patternPartOne = Pattern.PartOneXmas();

Console.WriteLine($"Part One -- Number of matches of XMAS and SAMX are {patternPartOne.Count(combinedPaths)}.");

//
// Part Two
//
const int MATCH_WIDTH = 3;
const int MATCH_HEIGHT = 3;

var patternPartTwo = Pattern.PartTwoMas();

bool isMatch(string[] matrix, int originRow, int originColumn)
{
    if (originRow + MATCH_HEIGHT - 1 >= matrix.Length)
    {
        return false;
    }
    else if (originColumn + MATCH_WIDTH - 1 >= matrix[0].Length)
    {
        return false;
    }

    string path_a = $"{matrix[originRow][originColumn]}{matrix[originRow + 1][originColumn + 1]}{matrix[originRow + 2][originColumn + 2]}";
    string path_b = $"{matrix[originRow][originColumn + 2]}{matrix[originRow + 1][originColumn + 1]}{matrix[originRow + 2][originColumn]}";
    string cross_combined_paths = $"{path_a}{PATH_SEPARATOR}{path_b}";

    return patternPartTwo.Count(cross_combined_paths) == 2;
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