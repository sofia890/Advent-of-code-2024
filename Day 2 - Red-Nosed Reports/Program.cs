using Day_2___Red_Nosed_Reports;

const int NO_INDEX = -1000;

List<int[]> GetLevelChange(List<int[]> reports)
{
    List<int[]> levelChangeReports = new();

    for (int i = 0; i < reports.Count; i++)
    {
        int[] levelDifference = new int[reports[i].Length - 1];

        for (int j = 0; j < reports[i].Length - 1; j++)
        {
            levelDifference[j] = reports[i][j + 1] - reports[i][j];
        }

        levelChangeReports.Add(levelDifference);
    }

    return levelChangeReports;
}
bool IsSafeLevelChange(int value, int signofFirst)
{
    const int MIN_LEVEL_CHANGE = 1;
    const int MAX_LEVEL_CHANGE = 3;

    int signofCurrent = Math.Sign(value);
    int absoluteDifference = Math.Abs(value);

    return signofCurrent == signofFirst &&
           MIN_LEVEL_CHANGE <= absoluteDifference &&
           absoluteDifference <= MAX_LEVEL_CHANGE;
}

bool IsReportSafe(int[] report)
{
    int signofFirst = Math.Sign(report[0]);

    for (int i = 0; i < report.Length; i++)
    {
        if (!IsSafeLevelChange(report[i], signofFirst))
        {
            return false;
        }
    }

    return true;
}
bool IsReportDampenedSafe(int[] report, int skipIndex)
{
    List<int> filteredReport = report.Where((value, index) => index != skipIndex).ToList();
    int signOfFirst = Math.Sign(filteredReport[1] - filteredReport[0]);

    // Allow only recursion to be 2 levels deep.
    bool dampened = skipIndex != NO_INDEX;

    for (int i = 0; i < filteredReport.Count - 1; i++)
    {
        int difference = filteredReport[i + 1] - filteredReport[i];

        if (!IsSafeLevelChange(difference, signOfFirst))
        {
            if (!dampened)
            {
                return (signOfFirst != Math.Sign(difference) && IsReportDampenedSafe(report, 0)) || // Check if removing the first element makes the report safe.
                       IsReportDampenedSafe(report, i) ||                                           // Check if removing the current element makes the report safe.
                       IsReportDampenedSafe(report, i + 1);                                         // Check if removing the next element makes the report safe.
            }
            else
            {
                return false;
            }
        }
    }

    return true;
}
int GetNrofDampenedSafeReports(List<int[]> reports)
{
    int nrofSafeReports = 0;

    foreach (int[] report in reports)
    {
        if (IsReportDampenedSafe(report, NO_INDEX))
        {
            nrofSafeReports++;
        }
    }

    return nrofSafeReports;
}
void PartOne(List<int[]> reports)
{
    List<int[]> levelChangeReports = GetLevelChange(reports);
    int nrofSafeReports = 0;

    for (int i = 0; i < levelChangeReports.Count; i++)
    {
        if (IsReportSafe(levelChangeReports[i]))
        {
            nrofSafeReports++;
        }
    }

    Console.WriteLine($"Part Two: Number of safe reports are {nrofSafeReports}");
}
void PartTwo(List<int[]> reports)
{
    Console.WriteLine($"Part Two: Number of safe dampened reports are {GetNrofDampenedSafeReports(reports)}");
}

var reports = Input.GetData();
PartOne(reports);
PartTwo(reports);