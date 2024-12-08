using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8___Resonant_Collinearity
{
    internal class Matrix<T> : IEnumerable<(int x, int y, T value)>
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
        #endregion IEnumerable

        #region
        public IEnumerator<(int x, int y, T value)> GetEnumerator()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    yield return (x, y, data[x, y]);
                }
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
