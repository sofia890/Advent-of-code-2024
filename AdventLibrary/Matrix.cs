using System.Collections;

namespace AdventLibrary
{
    public record Position(int x, int y)
    {
        public static Position operator +(Position a, Position b)
        {
            return new(a.x + b.x, a.y + b.y);
        }
        public static Position operator -(Position a, Position b)
        {
            return new(a.x - b.x, a.y - b.y);
        }
        public static Position operator -(Position a, (int x, int y) b)
        {
            return new(a.x - b.x, a.y - b.y);
        }
    }
    public static class MatrixParser
    {
        public static Matrix<char> Parse(string value)
        {
            string[] lines = value.Split("\r\n");

            int width = lines[0].Length;
            int height = lines.Length;
            var data = new char[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    data[x, y] = lines[y][x];
                }
            }

            return new(data);
        }
    }

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
        public Matrix(string rawData)
        {
            var lines = rawData.Split("\r\n")
                               .ToArray();

            Width = lines[0].Length;
            Height = lines.Length;

            data = new T[Width, Height];
            Array.Clear(data, 0, data.Length);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    data[x, y] = (T)Convert.ChangeType(lines[y][x], typeof(T));
                }
            }
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
            foreach (var (x, y) in Range(Width, Height))
            {
                yield return (x, y, data[x, y]);
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
        public T this[(int x, int y) position]
        {
            get
            {
                return data[position.x, position.y];
            }
            set
            {
                data[position.x, position.y] = value;
            }
        }
        public T this[Position position]
        {
            get
            {
                return data[position.x, position.y];
            }
            set
            {
                data[position.x, position.y] = value;
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
        public bool NotOutOfBounds(Position position)
        {
            return NotOutOfBounds(position.x, position.y);
        }
        #endregion
        public IEnumerable<MatrixRow<T>> AsRows()
        {
            for (int y = 0; y < Height; y++)
            {
                yield return new MatrixRow<T>(this, y);
            }
        }
        public IEnumerable<MatrixColumn<T>> AsColumns()
        {
            for (int x = 0; x < Width; x++)
            {
                yield return new MatrixColumn<T>(this, x);
            }
        }
        public static int GetDistance(Position a, Position b)
        {
            return Math.Abs(a.x - b.x) +
                   Math.Abs(a.y - b.y);
        }
        public static int GetDistance((int x, int y, T _) a, Position b)
        {
            return Math.Abs(a.x - b.x) +
                   Math.Abs(a.y - b.y);
        }
    }

    public class MatrixRow<T> : IEnumerable<(int x, int y, T value)>
    {
        #region Properties
        public int Y
        {
            get;
            private set;
        }
        #endregion

        Matrix<T> data;

        #region Constructors
        public MatrixRow(Matrix<T> data, int y)
        {
            this.data = data;
            Y = y;
        }
        #endregion
        #region IEnumerator
        public IEnumerator<(int x, int y, T value)> GetEnumerator()
        {
            for (int x = 0; x < data.Width; x++)
            {
                yield return (x, Y, data[x, Y]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }

    public class MatrixColumn<T> : IEnumerable<(int x, int y, T value)>
    {
        #region Properties
        public int X
        {
            get;
            private set;
        }
        #endregion

        Matrix<T> data;

        #region Constructors
        public MatrixColumn(Matrix<T> data, int x)
        {
            this.data = data;
            X = x;
        }
        #endregion
        #region IEnumerator
        public IEnumerator<(int x, int y, T value)> GetEnumerator()
        {
            for (int y = 0; y < data.Height; y++)
            {
                yield return (X, y, data[X, y]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
