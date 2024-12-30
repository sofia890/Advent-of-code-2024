using Day_23___LAN_Party;

using Network = (System.Collections.Generic.List<string> nodes, string password);

const int NO_PREFERRED_NETWORK_SIZE = 0;

IEnumerable<Network> GetInterConnectedNodes(
    Dictionary<string, List<string>> nodeInformation,
    string node,
    int preferredNetworkSize)
{
    var networkNodes = nodeInformation[node].ToList();

    List<List<string>> interConnectedNodes = [[node]];

    foreach (var currentNode in networkNodes)
    {
        var neighbours = nodeInformation[currentNode];
        var existingNetworks = interConnectedNodes.Where(x => x.All(y => neighbours.Contains(y)));

        List<List<string>> newNetworks = [[currentNode]];

        foreach (var network in existingNetworks)
        {
            var newSet = network.ToList();
            newSet.Add(currentNode);

            newNetworks.Add(newSet);
        }

        interConnectedNodes.AddRange(newNetworks);
    }

    var networks = interConnectedNodes.Select(x => (nodes: x, password: x.Order().Aggregate("", (a, b) => $"{a},{b}")[1..]));

    if (preferredNetworkSize > NO_PREFERRED_NETWORK_SIZE)
    {
        return networks.Where(x => x.nodes.Count == preferredNetworkSize);
    }
    else
    {
        return networks;
    }
}
IEnumerable<Network> GetNetworks(Connection[] connections, int preferredNetworkSize = NO_PREFERRED_NETWORK_SIZE)
{
    Dictionary<string, List<string>> nodeInformation = [];

    foreach (var currentConnection in connections)
    {
        _ = nodeInformation.TryAdd(currentConnection.nodeA, []);
        nodeInformation[currentConnection.nodeA].Add(currentConnection.nodeB);

        _ = nodeInformation.TryAdd(currentConnection.nodeB, []);
        nodeInformation[currentConnection.nodeB].Add(currentConnection.nodeA);
    }

    return nodeInformation.AsParallel()
                          .SelectMany(x => GetInterConnectedNodes(nodeInformation, x.Key, preferredNetworkSize))
                          .DistinctBy(x => x.password)
                          .OrderByDescending(x => x.nodes.Count);
}
void PartOne(Connection[] connections, string prefix)
{
    const int LAN_EXPECTED_SIZE = 3;
    var networks = GetNetworks(connections, LAN_EXPECTED_SIZE);
    var candidates = networks.AsParallel()
                             .Where(x => x.nodes.Count == LAN_EXPECTED_SIZE)
                             .Where(x => x.nodes.Any(y => y.StartsWith(prefix)));

    Console.WriteLine($"Part One: Number of set of three are {candidates.Count()}.");
}
void PartTwo(Connection[] connections, string prefix)
{
    var networks = GetNetworks(connections);
    var (_, password) = networks.AsParallel()
                                .OrderByDescending(x => x.password.Length)
                                .First();

    Console.WriteLine($"Part Two: LAN password is {password}.");
}

var (connections, prefix) = Input.GetData();
PartOne(connections, prefix);
PartTwo(connections, prefix);