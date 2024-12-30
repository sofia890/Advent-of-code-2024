using AdventLibrary;
using Day_20___Race_Condition;

using ShortcutInfo = System.Collections.Generic.IEnumerable<(int savedSteps, AdventLibrary.Position shortcutStart, AdventLibrary.Position shortcutEnd)>;

const char FREE = '.';
const char START = 'S';
const char END = 'E';

List<Position> FindPath(Matrix<char> matrix, int originX, int originY)
{
    var path = new List<Position>()
    {
        new(originX, originY),
    };

    var cells = new bool[matrix.Width, matrix.Height];
    Array.Clear(cells, 0, cells.Length);

    Position position = new(originX, originY);

    while (matrix[position] != END)
    {
        foreach (var movement in GridMovement.PossibleMovements())
        {
            var nextX = position.X + movement.X;
            var nextY = position.Y + movement.Y;
            var nextCellValue = matrix[nextX, nextY];

            if ((nextCellValue == FREE || nextCellValue == END) &&
                !cells[nextX, nextY])
            {
                path.Add(new(nextX, nextY));

                cells[nextX, nextY] = true;

                position = new(nextX, nextY);
            }
        }
    }

    return path;
}
/// <summary>
/// Determines if at least one element is skipped by going from the first index to the second.
/// Example:
///       ┌ indexA
///       │       ┌ indexB
///       ↓       ↓
///     | a | b | c | d | e | f | g | h | i | j |
///     | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
///       ↑       ↑
///       |       |
///       ├───────┘
///       └─────────────────> indexB - indexA = 2
/// </summary>
/// <param name="indexA">The first index.</param>
/// <param name="indexB">The second index.</param>
/// <returns>
///     True if there is at least one element that gets skipped by going from the first to the
///     second index.
///     False if either index is negative.
///     False if first index is after the second.
/// </returns>
bool IndexesSkipAtLeastOne(int indexA, int indexB)
{
    return indexA >= 0 &&
           indexB >= 0 &&
           indexA < indexB &&
           (indexB - indexA) > 2;
}
ShortcutInfo GetShortcuts(Matrix<char> matrix, List<Position> originalPath, int nrOfCheatSteps, int pathIndex)
{
    var startPosition = originalPath[pathIndex];

    for (int i = pathIndex; i < originalPath.Count; i++)
    {
        var currentPosition = originalPath[i];
        var distance = Math.Abs(startPosition.X - currentPosition.X) +
                       Math.Abs(startPosition.Y - currentPosition.Y);

        if (distance <= nrOfCheatSteps &&
            (i - pathIndex) > distance)
        {
            yield return (i - pathIndex - distance,
                          startPosition,
                          currentPosition);
        }
    }
}
int FindShortcuts(Matrix<char> matrix, int nrOfCheatSteps, int minSavedSteps)
{
    var start = matrix.First(x => x.value == START);
    var path = FindPath(matrix, start.x, start.y);
    var shortcutData = path.SelectMany((x, index) => GetShortcuts(matrix, path, nrOfCheatSteps, index))
                           .Select(x => (x.savedSteps, x.shortcutStart, x.shortcutEnd))
                           .OrderByDescending(x => x.savedSteps)
                           .DistinctBy(x => $"{x.shortcutStart}{x.shortcutEnd}")
                           .GroupBy(x => x.savedSteps)
                           .Select(x => (savedSteps: x.Key, count: x.Count()))
                           .OrderBy(x => x.savedSteps)
                           .Where(x => x.savedSteps >= minSavedSteps);

    int nrofGoodShortcuts = 0;

    foreach (var (savedSteps, count) in shortcutData)
    {
        nrofGoodShortcuts += count;

        Console.WriteLine($"{count} shortcuts with {savedSteps} steps saved. A total of {nrofGoodShortcuts}.");
    }

    return nrofGoodShortcuts;
}
void PartOne(Matrix<char> matrix, int nrOfCheatSteps, int minSavedSteps)
{
    var nrOfShortcuts = FindShortcuts(matrix, nrOfCheatSteps, minSavedSteps);
    Console.WriteLine($"Part One: {nrOfShortcuts} shortcuts save at least {minSavedSteps} steps.\n");
}
void PartTwo(Matrix<char> matrix, int nrOfCheatSteps, int minSavedSteps)
{
    var nrOfShortcuts = FindShortcuts(matrix, nrOfCheatSteps, minSavedSteps);
    Console.WriteLine($"Part Two: {nrOfShortcuts} shortcuts save at least {minSavedSteps} steps.\n");
}

(var matrix, var nrOfCheatStepsA, var nrOfCheatStepsB, var minSavedStepsA, var minSavedStepsB) = Input.GetData();
//PartOne(matrix, nrOfCheatStepsA, minSavedStepsA);
PartTwo(matrix, nrOfCheatStepsB, minSavedStepsB);