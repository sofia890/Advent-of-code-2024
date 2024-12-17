// See https://aka.ms/new-console-template for more information
using AdventLibrary;
using Day_15___Warehouse_Woes;

const string LARGE_BOX = "[]";
const char BOX = 'O';
const char WALL = '#';
const char FREE = '.';
const char SUBMARINE = '@';
const int NO_POSITION = -1;
const bool DEBUG_PRINTS_ENABLED = false;

(int x, int y) GetMovement(char move)
{
    return move switch
    {
        '^' => (0, -1),
        '<' => (-1, 0),
        '>' => (1, 0),
        'v' => (0, 1),
        _ => throw new NotImplementedException(),
    };
}
(bool result, (int x, int y) freePosition) IsLinePushable(Matrix<char> matrix, (int x, int y) start, (int x, int y) movement)
{
    var position = (start.x, start.y);

    while (matrix[position.x, position.y] == BOX)
    {
        position.x += movement.x;
        position.y += movement.y;
    }

    if (matrix[position.x, position.y] == FREE)
    {
        return (true, position);
    }
    else
    {
        return (false, (NO_POSITION, NO_POSITION));
    }
}
(bool result, IEnumerable<(int x, int y)> boxes) IsLinePushableLarge(Matrix<char> matrix, (int x, int y) start, (int x, int y) movement)
{
    var boxes = new List<(int x, int y)>();

    var workQueue = new Queue<(int x, int y)>();

    if (matrix[start] == LARGE_BOX[0])
    {
        workQueue.Enqueue(start);
        boxes.Add(start);
    }
    else
    {
        var boxOrigin = (x: start.x - 1, start.y);
        workQueue.Enqueue(boxOrigin);
        boxes.Add(boxOrigin);
    }

    while (workQueue.Any())
    {
        if (movement.y == 0)
        {
            var currentBoxLeftComponent = workQueue.Dequeue();
            currentBoxLeftComponent.x += movement.x;

            if (matrix[currentBoxLeftComponent] == WALL)
            {
                return (false, boxes);
            }
            else if (matrix[currentBoxLeftComponent] == LARGE_BOX[0])
            {
                workQueue.Enqueue(currentBoxLeftComponent);
                boxes.Add(currentBoxLeftComponent);
            }
            else if (matrix[currentBoxLeftComponent] == LARGE_BOX[1])
            {
                workQueue.Enqueue(currentBoxLeftComponent);
            }
        }
        else
        {
            var currentBoxLeftComponent = workQueue.Dequeue();
            currentBoxLeftComponent.x += movement.x;
            currentBoxLeftComponent.y += movement.y;
            var currentBoxRightComponent = (x: currentBoxLeftComponent.x + 1, currentBoxLeftComponent.y);

            if (matrix[currentBoxLeftComponent] == WALL ||
                matrix[currentBoxRightComponent] == WALL)
            {
                return (false, boxes);
            }
            else
            {
                if (matrix[currentBoxLeftComponent] == LARGE_BOX[0])
                {
                    workQueue.Enqueue(currentBoxLeftComponent);
                    boxes.Add(currentBoxLeftComponent);
                }
                else if (matrix[currentBoxLeftComponent] == LARGE_BOX[1])
                {
                    var newBoxOrigin = (x: currentBoxLeftComponent.x - 1, currentBoxLeftComponent.y);
                    workQueue.Enqueue(newBoxOrigin);
                    boxes.Add(newBoxOrigin);
                }

                if (matrix[currentBoxRightComponent] == LARGE_BOX[0])
                {
                    workQueue.Enqueue(currentBoxRightComponent);
                    boxes.Add(currentBoxRightComponent);
                }
            }
        }
    }

    return (true, boxes);
}

void PartOne(Matrix<char> matrix, char[] moves)
{
    var startPosition = matrix.Where(x => x.value == SUBMARINE).First();
    (int x, int y) position = (startPosition.x, startPosition.y);

    foreach (var move in moves)
    {
        if (DEBUG_PRINTS_ENABLED)
        {
            Console.WriteLine($"{matrix.ToString(x => x.ToString())}\n");
        }

        var movement = GetMovement(move);
        var nextPosition = (x: position.x + movement.x, y: position.y + movement.y);
        var nextPositionValue = matrix[nextPosition.x, nextPosition.y];

        if (nextPositionValue == FREE)
        {
            matrix[nextPosition.x, nextPosition.y] = SUBMARINE;
            matrix[position.x, position.y] = FREE;
            position = nextPosition;
            continue;
        }
        else if (nextPositionValue == WALL)
        {
            continue;
        }
        else if (nextPositionValue == BOX && IsLinePushable(matrix, nextPosition, movement) is (result: true, var freePosition))
        {
            matrix[nextPosition.x, nextPosition.y] = SUBMARINE;
            matrix[freePosition.x, freePosition.y] = BOX;
            matrix[position.x, position.y] = FREE;
            position = nextPosition;
            continue;
        }
    }

    var score = matrix.Where(cell => cell.value == BOX)
                      .Select(cell => cell.y * 100 + cell.x)
                      .Aggregate(0, (a, b) => a + b);
    Console.WriteLine($"Part One: Sum of GPS position are {score}.\n");
}
(int x, int y) GetClosestEdges(Matrix<char> matrix, (int x, int y) box)
{
    var closestEdge = box;


    return closestEdge;
}
void PartTwo(Matrix<char> matrix, char[] moves)
{
    //
    // Expand matrix
    //
    var largerMatrix = new Matrix<char>(matrix.Width * 2, matrix.Height);

    foreach (var cell in matrix)
    {
        var scaledPositioy = (x: cell.x * 2, cell.y);

        if (cell.value == BOX)
        {
            largerMatrix[scaledPositioy.x, scaledPositioy.y] = LARGE_BOX[0];
            largerMatrix[scaledPositioy.x + 1, scaledPositioy.y] = LARGE_BOX[1];
        }
        else if (cell.value == WALL)
        {
            largerMatrix[scaledPositioy.x, scaledPositioy.y] = WALL;
            largerMatrix[scaledPositioy.x + 1, scaledPositioy.y] = WALL;
        }
        else if (cell.value == FREE)
        {
            largerMatrix[scaledPositioy.x, scaledPositioy.y] = FREE;
            largerMatrix[scaledPositioy.x + 1, scaledPositioy.y] = FREE;
        }
        else
        {
            largerMatrix[scaledPositioy.x, scaledPositioy.y] = cell.value;
            largerMatrix[scaledPositioy.x + 1, scaledPositioy.y] = FREE;
        }
    }

    //
    // Move submarine
    //
    var startPosition = largerMatrix.Where(x => x.value == SUBMARINE).First();
    (int x, int y) position = (startPosition.x, startPosition.y);

    if (DEBUG_PRINTS_ENABLED)
    {
        Console.WriteLine("Initial state");
        Console.WriteLine($"{largerMatrix.ToString(x => x.ToString())}\n");
    }

    foreach (var move in moves)
    {
        var movement = GetMovement(move);
        var nextPosition = (x: position.x + movement.x, y: position.y + movement.y);
        var nextPositionValue = largerMatrix[nextPosition.x, nextPosition.y];

        if (nextPositionValue == FREE)
        {
            largerMatrix[nextPosition.x, nextPosition.y] = SUBMARINE;
            largerMatrix[position.x, position.y] = FREE;
            position = nextPosition;
        }
        else if (nextPositionValue == WALL)
        {
        }
        else if ((nextPositionValue == LARGE_BOX[0] || nextPositionValue == LARGE_BOX[1]) &&
                 IsLinePushableLarge(largerMatrix, nextPosition, movement) is (result: true, var boxes))
        {
            foreach (var box in boxes)
            {
                largerMatrix[box.x, box.y] = FREE;
                largerMatrix[box.x + 1, box.y] = FREE;
            }

            foreach (var box in boxes)
            {
                var boxNextPosition = (x: box.x + movement.x, y: box.y + movement.y);
                largerMatrix[boxNextPosition.x, boxNextPosition.y] = LARGE_BOX[0];
                largerMatrix[boxNextPosition.x + 1, boxNextPosition.y] = LARGE_BOX[1];
            }

            largerMatrix[nextPosition.x, nextPosition.y] = SUBMARINE;

            largerMatrix[position.x, position.y] = FREE;

            position = nextPosition;
        }

        if (DEBUG_PRINTS_ENABLED)
        {
            Console.WriteLine($"{move}");
            Console.WriteLine($"{largerMatrix.ToString(x => x.ToString())}\n");
        }
    }

    var score = largerMatrix.Where(cell => cell.value == LARGE_BOX[0])
                            .Select(cell => GetClosestEdges(matrix, (cell.x, cell.y)))
                            .Select(cell => cell.y * 100 + cell.x)
                            .Aggregate(0, (a, b) => a + b);
    Console.WriteLine($"Part One: Sum of GPS position are {score}.");
}

(var matrix, var moves) = Input.GetTrainingData();
PartOne(matrix, moves);
(matrix, moves) = Input.GetData();
PartTwo(matrix, moves);