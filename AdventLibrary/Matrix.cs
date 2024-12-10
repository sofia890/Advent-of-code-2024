using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventLibrary
{
    public class Matrix<T> : IEnumerable<(int x, int y, T value)>
    {
        #region Properties
        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get;
            private set;
        }
        #endregion

        T[,] data;

        #region Constructors
        public Matrix(T[,] data)
        {
            this.data = data;
            Width = data.GetLength(0);
            Height = data.GetLength(1);
        }
        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;

            data = new T[width, height];
            Array.Clear(data, 0, data.Length);
        }
        #endregion

        #region IEnumerator
        public static IEnumerable<(int x, int y)> Range(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    yield return (x, y);
                }
            }
        }
        public IEnumerator<(int x, int y, T value)> GetEnumerator()
        {
            foreach (var cell in Range(Width, Height))
            {
                yield return (cell.x, cell.y, data[cell.x, cell.y]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Indexer
        public T this[int x, int y]
        {
            get
            { 
                return data[x, y];
            }
            set
            {
                data[x, y] = value;
            }
        }
        #endregion

        #region ToString
        public string ToString(Func<T, string> func)
        {
            string illustrationLine = "";

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    illustrationLine += func(data[x, y]);
                }

                if (y != Height - 1)
                {
                    illustrationLine += "\n";
                }
            }

            return illustrationLine;
        }
        #endregion

        #region Bounds check
        public bool NotOutOfBounds(int x, int y)
        {
            return 0 <= x && x < Width &&
                   0 <= y && y < Height;
        }
        #endregion
    }
}
