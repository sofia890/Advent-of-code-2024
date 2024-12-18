using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLibrary
{
    public static class Parser
    {
        static Func<string, T> GetIntParser<T>(int offset) where T : IParsable<T>
        {
            return (string value) =>
            {
                return T.Parse(value[offset..], null);
            };
        }
        public static T[] ToIntegerArray<T>(string value, int offset = 0, string splitOn = ", ") where T : IParsable<T>
        {
            return value.Split(splitOn).Select(GetIntParser<T>(offset)).ToArray();
        }
        public static char[,] ToMatrix<T>(string data)
        {
            string[] lines = data.Split("\r\n");
            int height = lines.Length;
            int width = lines[0].Length;

            var matrix = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Want X-axis to be first dimension.
                    matrix[j, i] = lines[i][j];
                }
            }

            return matrix;
        }
    }
}
