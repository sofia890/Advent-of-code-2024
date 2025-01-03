
using Day_1___Historian_Hysteria;

void PartOne(List<int>[] data)
{
    foreach (var list in data)
    {
        list.Sort();
    }

    int distanceTotal = 0;

    for (int i = 0; i < data[0].Count; i++)
    {
        int distanceLocal = Math.Abs(data[0][i] - data[1][i]);
        distanceTotal += distanceLocal;
    }

    Console.WriteLine($"Part One: Total distance between lists is {distanceTotal}.\n");
}
void PartTwo(List<int>[] data)
{
    int simularityScoreTotal = 0;

    foreach (var value in data[0])
    {
        int simularity_score = value * data[1].Count(x => x == value);
        simularityScoreTotal += simularity_score;
    }

    Console.WriteLine($"Total simularity score is {simularityScoreTotal}.\n");
}

var data = Input.GetData();
PartOne(data);
PartTwo(data);