using AdventLibrary;

namespace Day_21___Keypad_Conundrum
{
    internal class Numpad : Pad
    {
        const string KEYS = "789\r\n456\r\n123\r\n\00A";
        public Numpad() : base(KEYS, 'A', '\0')
        {
        }
    }
    internal class KeyPad : Pad
    {
        const string KEYS = "\0^A\r\n<v>";
        public KeyPad() : base(KEYS, 'A', '\0')
        {
        }
    }
    internal class Pad
    {
        public event EventHandler<char>? KeyPressed;

        Matrix<char> matrix;
        Position position;
        char enterSymbol;
        char blockedSymbol;

        public Position Position => position;

        public Pad(string data, char enterSymbol, char blockedSymbol)
        {
            matrix = new Matrix<char>(data);
            position = new(matrix.First(x => x.value == enterSymbol));
            this.enterSymbol = enterSymbol;
            this.blockedSymbol = blockedSymbol;
        }
        public void Set(Position newPosition)
        {
            position = newPosition;
        }
        public void Set((int x, int y, char _) newPosition)
        {
            position = new(newPosition);
        }
        public void Set(char symbol)
        {
            position = new(matrix.First(x => x.value == symbol));
        }
        public void Reset()
        {
            position = new(matrix.First(x => x.value == enterSymbol));
        }
        public Pad Input(char keyPressed)
        {
            if (!TryInput(keyPressed))
            {
                throw new Exception($"Key press '{keyPressed}' caused an invalid state to occur.");
            }

            return this;
        }
        public bool TryInput(char keyPressed)
        {
            if (keyPressed == enterSymbol)
            {
                KeyPressed?.Invoke(this, matrix[position]);
            }
            else
            {
                var previousPosition = position.Copy();

                switch (keyPressed)
                {
                    case '<':
                        position.X--;
                        break;

                    case '>':
                        position.X++;
                        break;

                    case '^':
                        position.Y--;
                        break;

                    case 'v':
                        position.Y++;
                        break;
                }

                if (!matrix.NotOutOfBounds(position) || matrix[position] == blockedSymbol)
                {
                    position = previousPosition;

                    return false;
                }
            }

            return true;
        }
        public override string ToString()
        {
            return matrix.ToString((x, y, value) =>
            {
                var displayValue = value switch
                {
                    '\0' => ' ',
                    _ => value
                };

                if (position.X == x && position.Y == y)
                {
                    return $"[{displayValue}]";
                }
                return $" {displayValue} ";
            });
        }
    }
}
