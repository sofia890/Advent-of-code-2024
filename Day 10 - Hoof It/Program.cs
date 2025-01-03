using AdventLibrary;
using Day_10___Hoof_It;

const int MAX_N_STEPS = 9;

int CheckTrails(Matrix<byte> matrix, int originX, int originY, bool distinctPaths)
{
    Queue<(int x, int y)> workQueue = new();
    workQueue.Enqueue((originX, originY));

    for (int i = 1; i <= MAX_N_STEPS; i++)
    {
        Queue<(int x, int y)> newWorkQueue = new();

        while (workQueue.Count > 0)
        {
            var (positionX, positionY) = workQueue.Dequeue();

            foreach (var movement in GridMovement.PossibleMovements())
            {
                var nextX = positionX + movement.X;
                var nextY = positionY + movement.Y;

                if (matrix.NotOutOfBounds(nextX, nextY))
                {
                    var cellValue = matrix[nextX, nextY];

                    if (matrix[nextX, nextY] == i)
                    {
                        newWorkQueue.Enqueue((nextX, nextY));
                    }
                }
            }
        }

        workQueue = newWorkQueue;
    }

    if (distinctPaths)
    {
        return workQueue.Count;
    }
    else
    {
        return workQueue.Distinct().Count();
    }
}

int DetermineRating(Matrix<byte> matrix, bool distinctPaths)
{
    return matrix.AsParallel()
                 .Where(cell => cell.value == 0)
                 .Select(cell => (cell.x, cell.y, paths: CheckTrails(matrix, cell.x, cell.y, distinctPaths)))
                 .Where(cell => cell.paths > 0)
                 .Aggregate(0, (count, cell) => count + cell.paths);
}

void PartOne(Matrix<byte> matrix)
{
    Console.WriteLine($"Part One: Sum of peaks reachable from trailheads {DetermineRating(matrix, false)}.\n");
}
void PartTwo(Matrix<byte> matrix)
{
    Console.WriteLine($"Part Two: Sum of unique paths from trailheads {DetermineRating(matrix, true)}.\n");
}

var matrix = Input.GetData();
PartOne(matrix);
PartTwo(matrix);