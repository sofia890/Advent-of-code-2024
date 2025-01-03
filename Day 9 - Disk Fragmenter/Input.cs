namespace Day_9___Disk_Fragmenter
{
    internal class DiskInformation()
    {
        public int[] Disk { get; set; } = [];
        public Queue<int> FreeBlocks { get; } = new();
        public Queue<(int fileId, int index, int length)> Files { get; } = new();
    }

    internal class Input
    {
        public const int EMPTY_BLOCK = -1;
        static void Repeat(List<int> data, int value, int length)
        {
            for (int j = 0; j < length; j++)
            {
                data.Add(value);
            }
        }
        static DiskInformation ToArray(string diskData)
        {
            var diskInfo = new DiskInformation();

            var disk = new List<int>();
            int nextFileId = 0;
            int nextFreeAreId = -1;

            for (int i = 0; i < diskData.Length; i += 2)
            {
                int indexA = i;
                char valueA = diskData[indexA];
                int fileLength = int.Parse(valueA.ToString());

                diskInfo.Files.Enqueue((nextFileId, disk.Count, fileLength));

                Repeat(disk, nextFileId++, fileLength);

                int indexB = i + 1;

                if (indexB < diskData.Length)
                {
                    char valueB = diskData[indexB];
                    int nrofFreeBlocks = int.Parse(valueB.ToString());

                    for (int j = 0; j < nrofFreeBlocks; j++)
                    {
                        diskInfo.FreeBlocks.Enqueue(disk.Count + j);
                    }

                    Repeat(disk, nextFreeAreId--, nrofFreeBlocks);
                }
            }

            diskInfo.Disk = [.. disk];

            return diskInfo;
        }
        static DiskInformation Parse(string filePath)
        {
            string diskData = File.ReadAllText(filePath);

            return ToArray(diskData);
        }
        public static DiskInformation GetData()
        {
            return Parse("Data/Input.txt");
        }

        public static DiskInformation GeTrainingData()
        {
            return Parse("Data/TrainingInput.txt");
        }
    }
}
