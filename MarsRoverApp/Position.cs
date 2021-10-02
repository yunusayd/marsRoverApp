using System;

namespace MarsRoverApp
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public Position(int x, int y, Direction direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public Position(string input)
        {
            var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < 3)
                throw new ArgumentException($"Invalid Rover Position Input:{input}");

            if (!int.TryParse(values[0], out var x))
                throw new ArgumentException($"Invalid Rover Position X Input:{input}");

            if (!int.TryParse(values[1], out var y))
                throw new ArgumentException($"Invalid Rover Position Y Input:{input}");

            if (!Enum.TryParse(typeof(Direction), values[2], out var direction))
                throw new ArgumentException($"Invalid Rover Direction Input:{input}");

            this.X = x;
            this.Y = y;
            this.Direction = (Direction)direction;
        }

        public string GetInfo()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}
