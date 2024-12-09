using Day_9___Disk_Fragmenter;
using System.Linq;

long CalculateChecksumForDisk(int[] disk)
{
    return disk.Select((fileId, index) => (fileId, index))
               .Where(entry => entry.fileId >= 0)
               .Select(entry => (long)(entry.fileId * entry.index))
               .Aggregate((a, b) => a + b);
}

void PartOne(DiskInformation diskInfo)
{
    var disk = diskInfo.Disk.ToArray();

    var usedBlocks = disk.Select((fileId, index) => (fileId, index))
                         .Where(entry => entry.fileId >= 0);

    foreach ((int fileId, int index) in usedBlocks.Reverse())
    {
        if (diskInfo.FreeBlocks.Peek() < index)
        {
            int freeBlockIndex = diskInfo.FreeBlocks.Dequeue();
            disk[freeBlockIndex] = fileId;
            disk[index] = Input.EMPTY_BLOCK;

            diskInfo.FreeBlocks.Enqueue(index);
        }
    }

    Console.WriteLine($"Part One: Disk checksum is {CalculateChecksumForDisk(disk)}.");
}
void PartTwo(DiskInformation diskInfo)
{
    var disk = diskInfo.Disk.ToArray();

    foreach (var file in diskInfo.Files.OrderByDescending(x => x.fileId))
    {
        var largestFreeArea = disk.AsParallel()
                                  .Select((value, index) => (value, index))
                                  .Where(x => x.index < file.index)
                                  .Where(x => x.value < 0)
                                  .GroupBy(x => x.value)
                                  .Select(x =>
                                  {
                                      var area = x.First();
                                      return (area.value, area.index, length: x.Count());
                                  })
                                  .Where(x => x.length >= file.length)
                                  .FirstOrDefault();

        if (largestFreeArea.length > 0)
        {
            for (int i = 0; i < file.length; i++)
            {
                disk[largestFreeArea.index + i] = file.fileId;
                disk[file.index + i] = Input.EMPTY_BLOCK;
            }
        }
    }

    Console.WriteLine($"Part Two: Disk checksum is {CalculateChecksumForDisk(disk)}.");
}

var diskInfo = Input.GetData();
PartOne(diskInfo);
PartTwo(diskInfo);