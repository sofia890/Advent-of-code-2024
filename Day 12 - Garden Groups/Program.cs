using AdventLibrary;
using Day_12___Garden_Groups;

const int MAX_N_SIDES = 4;

bool isNeighbour((int x, int y) a, (int x, int y) b)
{
    return (Math.Abs(a.y - b.y) + Math.Abs(a.x - b.x)) == 1;
}
bool IsPartOfArea((char type, List<(int x, int y)> elements) area, (int x, int y, char type) cell)
{
    return area.type == cell.type &&
           area.elements.Any(
               element => isNeighbour((cell.x, cell.y), (element.x, element.y))
            );
}
int CalculateCostForPlot(List<(int x, int y)> elements)
{
    return elements.Count * elements.Aggregate(0, (a, cellA) => a + MAX_N_SIDES - elements.Where(cellB => isNeighbour(cellA, cellB)).Count());
}
bool IsMatch(Matrix<char> data, char type, (int x, int y) position)
{
    return data.NotOutOfBounds(position.x, position.y) && data[position.x, position.y] == type;
}
int CalculateCostForPlotBulkDiscount(Matrix<char> data, List<(int x, int y)> elements, char type)
{
    return elements.Count * elements.Aggregate(0,
        (a, cellA) =>
        {
            int nrOfSidesWithoutFence = elements.Where(cellB => isNeighbour(cellA, cellB)).Count();

            if (nrOfSidesWithoutFence != 4)
            {
                // Top, right
                if (IsMatch(data, type, (cellA.x + 1, cellA.y)) &&
                    !IsMatch(data, type, (cellA.x, cellA.y - 1)) &&
                    !IsMatch(data, type, (cellA.x + 1, cellA.y - 1)))
                {
                    nrOfSidesWithoutFence++;
                }
                // Bottom right
                if (IsMatch(data, type, (cellA.x + 1, cellA.y)) &&
                    !IsMatch(data, type, (cellA.x, cellA.y + 1)) &&
                    !IsMatch(data, type, (cellA.x + 1, cellA.y + 1)))
                {
                    nrOfSidesWithoutFence++;
                }
                // Right, top
                if (IsMatch(data, type, (cellA.x, cellA.y - 1)) &&
                    !IsMatch(data, type, (cellA.x + 1, cellA.y)) &&
                    !IsMatch(data, type, (cellA.x + 1, cellA.y - 1)))
                {
                    nrOfSidesWithoutFence++;
                }
                // Left, top
                if (IsMatch(data, type, (cellA.x, cellA.y - 1)) &&
                    !IsMatch(data, type, (cellA.x - 1, cellA.y)) &&
                    !IsMatch(data, type, (cellA.x - 1, cellA.y - 1)))
                {
                    nrOfSidesWithoutFence++;
                }
            }

            return a + MAX_N_SIDES - nrOfSidesWithoutFence;
        });
}
List<(char type, List<(int x, int y)> elements)> GroupCellsIntoPlots(Matrix<char> data)
{
    var plots = new List<(char type, List<(int x, int y)> elements)>();

    foreach (var cell in data)
    {
        var plotsConnectedByCell = plots.Where(currentPlot => IsPartOfArea(currentPlot, cell)).ToArray();

        if (plotsConnectedByCell.Any())
        {
            var mergedPlot = plotsConnectedByCell.SelectMany(currentPlot => currentPlot.elements)
                                                 .ToList();
            mergedPlot.Add((cell.x, cell.y));

            plots.Add((cell.value, mergedPlot));

            foreach (var plot in plotsConnectedByCell)
            {
                _ = plots.Remove(plot);
            }
        }
        else
        {
            plots.Add((cell.value, new List<(int x, int y)>() { (cell.x, cell.y) }));
        }
    }

    return plots;
}
void PartOne(Matrix<char> data)
{
    var plots = GroupCellsIntoPlots(data);
    var cost = plots.Aggregate(0, (a, b) => a + CalculateCostForPlot(b.elements));

    Console.WriteLine($"Part One: Cost for fencing is {cost}.");
}
void PartTwo(Matrix<char> data)
{
    var plots = GroupCellsIntoPlots(data);
    var cost = plots.Aggregate(0, (a, b) => a + CalculateCostForPlotBulkDiscount(data, b.elements, b.type));

    Console.WriteLine($"Part One: Cost when bulk discount is applied {cost}.");
}

var data = Input.GetData();
PartOne(data);
PartTwo(data);