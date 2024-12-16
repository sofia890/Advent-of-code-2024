using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLibrary
{
    public static class GridMovement
    {
        public static IEnumerable<(int x, int y)> PossibleMovements()
        {
            yield return (0, -1);
            yield return (1, 0);
            yield return (0, 1);
            yield return (-1, 0);
        }
    }
}
