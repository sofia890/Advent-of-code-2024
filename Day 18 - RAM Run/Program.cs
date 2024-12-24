using AdventLibrary;
using Day_18___RAM_Run;
using Placement = (int x, int y, int steps, System.Collections.Generic.List<AdventLibrary.Position> path);

const char WALL = '#';
const char FREE = '.';
const char WALKED = 'O';
const char LAST_BYTE = '@';

IEnumerable<Position> WalkGrid(Matrix<char> matrix, int originX, int originY)
{
    var paths = new List<List<Position>>();

    var cells = new bool[matrix.Width, matrix.Height];
    Array.Clear(cells, 0, cells.Length);

    PriorityQueue<Placement, int> workQueue = new();
    workQueue.Enqueue((originX, originY, 0, []), 0);

    while (workQueue.Count > 0)
    {
        var position = workQueue.Dequeue();

        foreach (var movement in GridMovement.PossibleMovements())
        {
            var nextX = position.x + movement.x;
            var nextY = position.y + movement.y;

            if (matrix.NotOutOfBounds(nextX, nextY) &&
                matrix[nextX, nextY] != WALL &&
                !position.path.Contains(new(nextX, nextY)) &&
                !cells[nextX, nextY])
            {
                var nextSteps = position.steps + 1;

                var nextPath = position.path.ToList();
                nextPath.Add(new(nextX, nextY));

                cells[nextX, nextY] = true;

                if (nextX == matrix.Width - 1 && nextY == matrix.Height - 1)
                {
                    paths.Add(nextPath);
                }
                else
                {
                    workQueue.Enqueue((nextX, nextY, nextSteps, nextPath), nextSteps);
                }
            }
        }
    }

    if (paths.Count > 0)
    {
        return paths.OrderBy(x => x.Count).First();
    }
    else
    {
        return new List<Position>();
    }
}
void PlaceFallenBytes(Matrix<char> matrix, IList<Position> bytes, int index = 0, int amount = 1)
{
    for (int i = index; i < index + amount && i < bytes.Count; i++)
    {
        matrix[bytes[i]] = WALL;
    }
}
bool CheckUoTo(IList<Position> bytes, int width, int height, int nrofFallenBytes)
{
    var matrix = new Matrix<char>(width, height);
    PlaceFallenBytes(matrix, bytes, 0, nrofFallenBytes);

    return WalkGrid(matrix, 0, 0).Any();
}
void PartOne(IList<Position> bytes, int width, int height, int nrofFallenBytes)
{
    var matrix = new Matrix<char>(width, height);
    PlaceFallenBytes(matrix, bytes, 0, nrofFallenBytes);

    var path = WalkGrid(matrix, 0, 0);

    foreach (var position in path)
    {
        matrix[position] = WALKED;
    }

    Console.WriteLine(matrix.ToString(x => (x == 0) ? FREE.ToString() : x.ToString()));

    Console.WriteLine($"Part One: Number of steps to clear maze {path.Count()}.\n");
}
void PartTwo(IList<Position> bytes, int width, int height, int nrofFallenBytes)
{
    //
    // Test byte placements
    //
    var nrofPlacedBytes = Search<int>.FindThreshold(0, bytes.Count, x => !CheckUoTo(bytes, width, height, x));

    //
    // Print matrix
    //
    var matrix = new Matrix<char>(width, height);
    PlaceFallenBytes(matrix, bytes, 0, nrofPlacedBytes);

    var lastPlacedByte = bytes[nrofPlacedBytes - 1];
    matrix[lastPlacedByte] = LAST_BYTE;

    Console.WriteLine(matrix.ToString(x => (x == 0) ? FREE.ToString() : x.ToString()));

    //
    // Print results
    //
    Console.WriteLine($"Part Two: Position of first byte that blocks is {lastPlacedByte}.\n");
}

(var bytes, var width, var height, int nrofFallenBytes) = Input.GetData();
PartOne(bytes, width, height, nrofFallenBytes);
PartTwo(bytes, width, height, nrofFallenBytes);