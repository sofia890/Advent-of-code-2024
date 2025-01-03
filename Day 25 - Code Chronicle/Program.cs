﻿using AdventLibrary;
using Day_25___Code_Chronicle;

void PartOne(List<int[]> keys, List<int[]> locks, int height)
{
    var nrOfMatches = Permutations.Each(keys, locks)
                                  .Where(x =>
                                  {
                                      return Enumerable.Range(0, x.a.Length)
                                                       .All(i => x.a[i] + x.b[i] <= height);
                                  })
                                  .Count();

    Console.WriteLine($"Part One: The number of key and lock candiadtes are {nrOfMatches}.");
}

var (keys, locks, height) = Input.GetData();
PartOne(keys, locks, height);