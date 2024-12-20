using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLibrary
{
    public static class GridMovement
    {
        public static IEnumerable<Position> PossibleMovements()
        {
            yield return new(0, -1);
            yield return new(1, 0);
            yield return new(0, 1);
            yield return new(-1, 0);
        }
    }
}
