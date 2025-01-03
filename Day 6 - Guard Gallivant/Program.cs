
using Day_6___Guard_Gallivant;

TileTypes[] GetGuardPattern() => [TileTypes.GuardFacingLeft, TileTypes.GuardFacingRight, TileTypes.GuardFacingUp, TileTypes.GuardFacingDown];

const int MAX_NROF_VISITS_PER_TILE = 2;
const int NROF_DIRECTION = 4;

(int x_movement, int y_movement)[] GetMovementTable() => [(-1, 0), (0, -1), (1, 0), (0, 1)];

(int x, int y, int direction) GetGuardStartPosition(TileTypes[,] area)
{
    var guardPattern = GetGuardPattern();

    int width = area.GetLength(0);
    int height = area.GetLength(1);

    for (int x = 0; x < height; x++)
    {
        for (int y = 0; y < width; y++)
        {
            TileTypes tile = area[x, y];

            if (guardPattern.Contains(tile))
            {
                int direction = tile switch
                {
                    TileTypes.GuardFacingLeft => 0,
                    TileTypes.GuardFacingUp => 1,
                    TileTypes.GuardFacingRight => 2,
                    TileTypes.GuardFacingDown => 3,

                    _ => throw new Exception("Guard has been lost, should not happen!"),
                };

                return (x, y, direction);
            }
        }
    }

    throw new Exception("Could not find guard.");
}
bool IsInsideBounds(int x, int y, int width, int height)
{
    return 0 <= x & x < width &
           0 <= y & y < height;
}
(int x, int y, int direction, bool insideBounds) Move(TileTypes[,] area, int x, int y, int width, int height, int direction, (int x_movement, int y_movement)[] movementTable)
{
    (int x_movement, int y_movement) = movementTable[direction];
    int new_x = x + x_movement;
    int new_y = y + y_movement;

    bool insideBounds = IsInsideBounds(new_x, new_y, width, height);

    if (insideBounds && area[new_x, new_y] == TileTypes.Blocked)
    {
        return (x, y, (direction + 1) % NROF_DIRECTION, insideBounds);
    }
    else
    {
        return (new_x, new_y, direction, insideBounds);
    }
}
unsafe (bool stuckInLoop, int nrofVisitedTiles) TraverseTiles(TileTypes[,] area, int x, int y, int direction, (int x_movement, int y_movement)[] movementTable)
{
    int width = area.GetLength(0);
    int height = area.GetLength(1);
    var tileVisitCounter = new int[width, height];
    Array.Clear(tileVisitCounter, 0, tileVisitCounter.Length);

    int nrofVisistedTiles = 0;
    bool insideBounds = true;

    while (insideBounds && tileVisitCounter[x, y] <= MAX_NROF_VISITS_PER_TILE)
    {
        nrofVisistedTiles += (tileVisitCounter[x, y] == 0) ? 1 : 0;
        tileVisitCounter[x, y] += 1;

        (x, y, direction, insideBounds) = Move(area, x, y, width, height, direction, movementTable);
    }

    return (insideBounds, nrofVisistedTiles);
}
void ParOne(TileTypes[,] area)
{
    (int x, int y, int direction) = GetGuardStartPosition(area);
    (_, int nrofVisitedTiles) = TraverseTiles(area, x, y, direction, GetMovementTable());

    Console.WriteLine($"Part One: Number of unique tiles visited are {nrofVisitedTiles}.");
}
void PartTwo(TileTypes[,] area)
{

    var guardPattern = GetGuardPattern();

    (int guard_x, int guard_y, int direction) = GetGuardStartPosition(area);

    int timeouts = 0;

    var movementTable = GetMovementTable();

    int width = area.GetLength(0);
    int height = area.GetLength(1);

    for (int obstacle_x = 0; obstacle_x < height; obstacle_x++)
    {
        for (int obstacle_y = 0; obstacle_y < width; obstacle_y++)
        {
            //
            // Skip blocked tiles and guard tiles
            //
            if (area[obstacle_x, obstacle_y] == TileTypes.Blocked)
            {
                continue;
            }
            else if (guardPattern.Contains(area[obstacle_x, obstacle_y]))
            {
                continue;
            }

            //
            // Block open tile
            //
            area[obstacle_x, obstacle_y] = TileTypes.Blocked;

            //
            // Check if guard gets stuck in a loop
            //
            if (TraverseTiles(area, guard_x, guard_y, direction, movementTable) is (stuckInLoop: true, _))
            {
                timeouts++;
            }

            //
            // Restore tile
            //
            area[obstacle_x, obstacle_y] = TileTypes.OpenSpace;
        }
    }

    Console.WriteLine($"Part Two: Number of possible loops {timeouts}.");
}

var area = Input.GetData();
ParOne(area);
PartTwo(area);