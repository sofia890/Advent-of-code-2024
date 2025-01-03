using System.Numerics;

namespace AdventLibrary
{
    public static class Permutations
    {
        private class WorkItem<RefDataType, RefCountType>(RefDataType value, RefCountType count)
        {
            public RefDataType Value { get; } = value;
            public RefCountType Count { get; set; } = count;
        }
        public static IEnumerable<(RefDataType a, RefDataType b)> Each<RefDataType>(
            IEnumerable<RefDataType> setA,
            IEnumerable<RefDataType> setB
        )
        {
            foreach (var a in setA)
            {
                foreach (var b in setB)
                {
                    yield return (a, b);
                }
            }
        }
        public static RefCountType Count<RefDataType, RefKeyType, RefPriorityType, RefCountType>(
            RefDataType initialValue,
            RefCountType seed,
            Func<RefDataType, RefPriorityType> getPriority,
            Func<RefDataType, (IEnumerable<RefDataType> newElements, RefCountType nrofDone)> expand,
            Func<RefDataType, RefKeyType> getKey
        )
            where RefDataType : notnull
            where RefKeyType : notnull
            where RefPriorityType : INumber<RefPriorityType>
            where RefCountType : INumber<RefCountType>
        {
            var lookup = new Dictionary<RefKeyType, WorkItem<RefDataType, RefCountType>>();

            var counter = seed;

            var workQueue = new PriorityQueue<WorkItem<RefDataType, RefCountType>, RefPriorityType>();
            workQueue.Enqueue(new(initialValue, RefCountType.One), getPriority(initialValue));

            while (workQueue.Count > 0)
            {
                var item = workQueue.Dequeue();
                (var newElements, var nrOfDone) = expand(item.Value);

                counter += nrOfDone * item.Count;

                foreach (var element in newElements)
                {
                    var key = getKey(element);

                    if (lookup.ContainsKey(key))
                    {
                        lookup[getKey(element)].Count += item.Count;
                    }
                    else
                    {
                        var newItem = new WorkItem<RefDataType, RefCountType>(element, item.Count);
                        lookup.Add(key, newItem);
                        workQueue.Enqueue(newItem, getPriority(element));
                    }
                }
            }

            return counter;
        }
    }
}
