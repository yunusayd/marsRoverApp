using System;

namespace MarsRoverApp
{
    public class Grid
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(X));
                _x = value;
            }
        }
        public int Y
        {
            get => _y; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(Y));
                _y = value;
            }
        }

        public Grid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Grid(string input)
        {
            var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < 2) throw new ArgumentException($"Invalid Grid Size Input:{input}");

            if (!int.TryParse(values[0], out var x)) throw new ArgumentException($"Invalid Grid Size X Input:{input}");

            if (!int.TryParse(values[1], out var y)) throw new ArgumentException($"Invalid Grid Size Y Input:{input}");

            X = x;
            Y = y;
        }
    }
}
