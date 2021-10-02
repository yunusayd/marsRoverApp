using System;

namespace MarsRoverApp
{
    public class Rover
    {
        public Grid Grid { get; }
        public Position Position { get; }
        public Rover(Grid grid, Position position)
        {
            this.Grid = grid;
            this.Position = position;
        }
        private void Move(Moves move)
        {
            if (move == Moves.M)
            {
                switch (Position.Direction)
                {
                    case Direction.E:
                        Position.X += 1;
                        break;
                    case Direction.W:
                        Position.X -= 1;
                        break;
                    case Direction.N:
                        Position.Y += 1;
                        break;
                    case Direction.S:
                        Position.Y -= 1;
                        break;
                }

                if (Position.X < 0) Position.X = 0;
                if (Position.Y < 0) Position.Y = 0;

                if (Position.X > Grid.X) Position.X = Grid.X;
                if (Position.Y > Grid.Y) Position.Y = Grid.Y;
            }
            else
            {
                Position.Direction = Turn(move);
            }
        }
        // negative mod fix
        private int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
        private Direction Turn(Moves move)
        {
            var oldDirection = Position.Direction;
            var newDirection = (Direction)Mod((int)oldDirection + (int)move, 4);
            return newDirection;
        }

        public void MoveSteps(string input)
        {
            foreach (var moveCh in input)
            {
                if (!Enum.TryParse(typeof(Moves), moveCh.ToString(), out var move))
                    throw new ArgumentException($"Invalid Move {moveCh} in {input}");
                Move((Moves)move);
            }
        }

    }
}
