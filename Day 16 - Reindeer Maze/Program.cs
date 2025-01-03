using AdventLibrary;
using Day_16___Reindeer_Maze;
using Move = (int x, int y, int rotation, int cost);
using Position = (int x, int y);
using Trek = (int x, int y, int direction, int score, System.Collections.Generic.List<(int x, int y)> trail);

const int N_DIRECTIONS = 4;

Position GetMovementFromDirection(int direction)
{
    return direction switch
    {
        0 => (0, -1),
        1 => (1, 0),
        2 => (0, 1),
        3 => (-1, 0),
        _ => throw new NotImplementedException(),
    };
}
Move[] GetPossibleRotations(Trek path)
{
    const int ROTATION_COST = 1000;
    const int LEFT_ROTATION = -1;
    const int RIGHT_ROTATION = 1;

    return [(path.x, path.y, Rotate(path.direction, RIGHT_ROTATION), path.score + ROTATION_COST),
            (path.x, path.y, Rotate(path.direction, LEFT_ROTATION), path.score + ROTATION_COST)];
}
int Rotate(int direction, int rotation)
{
    return (direction + rotation + N_DIRECTIONS) % N_DIRECTIONS;
}
IEnumerable<Move> GetValidMoves(Matrix<char> matrix, Trek path, bool[,,] visitedTiles)
{
    const int MOVE_COST = 1;
    var (movementX, movementY) = GetMovementFromDirection(path.direction);
    var nextX = path.x + movementX;
    var nextY = path.y + movementY;
    var stepForward = (nextX, nextY, path.direction, path.score + MOVE_COST);

    Move[] possibleMoves = [stepForward, .. GetPossibleRotations(path)];

    foreach (var move in possibleMoves)
    {
        const char WALL = '#';

        if (matrix[move.x, move.y] != WALL &&
            !visitedTiles[move.x, move.y, move.rotation])
        {
            yield return move;
        }
    }
}
List<(int score, List<Position> trail)> GetPaths(Matrix<char> matrix)
{
    var workQueue = new PriorityQueue<Trek, int>();
    var fullPaths = new List<(int score, List<Position> trail)>();

    //
    // Setup cell tracking, used to avoid infitine loops.
    //
    var visitedCells = new bool[matrix.Width, matrix.Height, N_DIRECTIONS];
    Array.Clear(visitedCells, 0, visitedCells.Length);

    //
    // Seed work queue.
    //
    const char START = 'S';
    const char END = 'E';
    const int EAST = 1;
    (var startX, int startY, _) = matrix.Where(cell => cell.value == START).First();
    workQueue.Enqueue((startX, startY, EAST, 0, []), 0);

    //
    // Take a step for the trek with the lowest score.
    //
    while (workQueue.Count > 0)
    {
        var currentTrek = workQueue.Dequeue();
        currentTrek.trail.Add((currentTrek.x, currentTrek.y));

        //
        // Maintenance of cell tracking.
        //
        visitedCells[currentTrek.x, currentTrek.y, currentTrek.direction] = true;

        //
        // Handle goal reached.
        //
        if (matrix[currentTrek.x, currentTrek.y] == END)
        {
            fullPaths.Add((currentTrek.score, currentTrek.trail));
            continue;
        }

        //
        // Move.
        //
        foreach ((int x, int y, int rotation, int score) in GetValidMoves(matrix, currentTrek, visitedCells))
        {
            workQueue.Enqueue((x, y, rotation, score, currentTrek.trail.ToList()), score);
        }
    }

    return fullPaths;
}
void FillAndPrint(Matrix<char> matrix, IEnumerable<Position> visitedCells)
{
    const char VISITED = 'O';

    foreach (var (x, y) in visitedCells)
    {
        matrix[x, y] = VISITED;
    }

    Console.WriteLine(matrix.ToString(x => x.ToString()));
}
void PartOne(Matrix<char> matrix)
{
    var fullPaths = GetPaths(matrix);
    var visitedCells = fullPaths.OrderBy(x => x.score)
                                .First()
                                .trail;

    FillAndPrint(matrix, visitedCells);
    Console.WriteLine($"Part One: Score is {fullPaths.OrderBy(x => x.score).First().score}.\n");
}
void PartTwo(Matrix<char> matrix)
{
    var fullPaths = GetPaths(matrix);
    var lowestScore = fullPaths.OrderBy(x => x.score).First().score;
    var visitedCells = fullPaths.Where(cell => cell.score == lowestScore)
                                .SelectMany(x => x.trail)
                                .Distinct();

    FillAndPrint(matrix, visitedCells);
    Console.WriteLine($"Part Two: Score is {visitedCells.Count()}.\n");
}
Matrix<char> GetData()
{
    return Input.GetData();
}

PartOne(GetData());
PartTwo(GetData());