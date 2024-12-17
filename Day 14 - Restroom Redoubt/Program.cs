using AdventLibrary;
using Day_14___Restroom_Redoubt;

int GetQuadrant(Robot robot, long midX, long midY)
{
    if (robot.Position.X < midX)
    {
        if (robot.Position.Y < midY)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    else
    {
        if (robot.Position.Y < midY)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}

void Print(IEnumerable<Robot> robots, (int width, int height) areaSize, long midX, long midY)
{
    var matrix = new int[areaSize.width, areaSize.height];
    Array.Clear(matrix, 0, matrix.Length);

    foreach (var robot in robots)
    {
        matrix[robot.Position.X, robot.Position.Y] += 1;
    }

    for (int j = 0; j < areaSize.height; j++)
    {
        for (int i = 0; i < areaSize.width; i++)
        {
            string abc = matrix[i, j] > 0 ? "." : " ";
            //if (i != midX && j != midY)
            {
                Console.Write($"{abc}");
            }
            //else
            //{
            //    Console.Write(" ");
            //}
        }
        Console.Write("\n");
    }
}

void PartOne(IEnumerable<Robot> robots, (int width, int height) areaSize, int steps)
{
    long midX = areaSize.width / 2;
    long midY = areaSize.height / 2;

    var safetlyScore = robots.Select(x => x.Update(steps, areaSize.width, areaSize.height))
                             .Where(x => x.Position.X != midX && x.Position.Y != midY)
                             .GroupBy(x => GetQuadrant(x, midX, midY))
                             .Select(x =>
                             {
                                 return (quadrant: GetQuadrant(x.First(), midX, midY),
                                         nrofRobots: x.Count());
                             })
                             .Aggregate(1L, (a, b) => a * b.nrofRobots);

    Print(robots, areaSize, midX, midY);

    Console.WriteLine($"Part One: Safety score {safetlyScore}.");
}
int TreeScore(Matrix<int> matrix, int x, int y)
{
    int newX = x;
    int newY = y + 1;
    int score = 1;
    int offset = 1;

    while (matrix.NotOutOfBounds(newX, newY) && matrix[newX, newY] > 0)
    {
        for (int i = -offset; i <= offset; i++)
        {
            if (!matrix.NotOutOfBounds(newX + i, newY) || matrix[newX + i, newY] == 0)
            {
                return score;
            }
        }

        score++;
        newY++;
        offset++;
    }

    return score;
}
void PartTwo(IEnumerable<Robot> robots, (int width, int height) areaSize, int steps)
{
    List<(int seconds, int score)> scores = new();

    for (int second = 1; second < areaSize.width * areaSize.height; second++)
    {
        foreach(var robot in robots)
        {
            robot.Update(1, areaSize.width, areaSize.height);
        }

        var data = new int[areaSize.width, areaSize.height];
        Array.Clear(data, 0, data.Length);

        Matrix<int> matrix = new(data);

        foreach (var robot in robots)
        {
            matrix[(int)robot.Position.X, (int)robot.Position.Y] += 1;
        }

        scores.Add((second, matrix.Select(a => TreeScore(matrix, a.x, a.y)).OrderByDescending(x => x).First()));
    }

    var a = scores.OrderByDescending(x => x.score).First();
    Console.WriteLine($"Part One: Stupid christmass tree at {(a.seconds, a.score)}.");
}

(var robots, var areaSize, var steps) = Input.GetData();
PartOne(robots, areaSize, 8168);
(robots, areaSize, steps) = Input.GetData();
PartTwo(robots, areaSize, steps);