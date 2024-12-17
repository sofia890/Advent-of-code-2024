using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17___Chronospatial_Computer
{
    internal static class Input
    {
        public static int[] Parse(string value)
        {
            return value.Split(',').Select(int.Parse).ToArray();
        }
        public static (int[] opcodes, int a, int b, int c) GetData()
        {
            return (Parse("2,4,1,3,7,5,0,3,4,1,1,5,5,5,3,0"), 45483412, 0, 0);
        }
        public static (int[] opcodes, int a, int b, int c) GetTrainingData()
        {
            return (Parse("0,1,5,4,3,0"), 729, 0, 0);
        }
    }
}
