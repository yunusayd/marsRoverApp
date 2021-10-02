using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverApp
{
    public class Grid
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Grid(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Grid(string input)
        {
            var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < 2)
                throw new ArgumentException($"Invalid Grid Size Input:{input}");

            if (!int.TryParse(values[0], out var x))
                throw new ArgumentException($"Invalid Grid Size X Input:{input}");

            if (!int.TryParse(values[1], out var y))
                throw new ArgumentException($"Invalid Grid Size Y Input:{input}");

            this.X = x;
            this.Y = y;
        }
    }
}
