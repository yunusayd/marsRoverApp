using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input:(Empty line means input has done!)");
            var inputDone = false;
            List<string> lines = new();
            while (!inputDone)
            {
                var line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                    lines.Add(line);
                else
                    inputDone = true;
            }

            var rovers = Process(lines);
            Console.WriteLine("Output:");
            Console.WriteLine(GetOutPut(rovers));

            Console.ReadKey();
        }

        public static string GetOutPut(List<Rover> rovers)
        {
            var result = new StringBuilder();
            foreach (var rover in rovers)
            {
                result.AppendLine(rover.Position.GetInfo());
            }

            return result.ToString();
        }

        public static List<Rover> Process(List<string> lines)
        {
            if (lines.Count < 1)
                throw new ArgumentException("Invalid Input");

            var grid = new Grid(lines[0]);
            List<Rover> rovers = new();

            for (var i = 1; i < lines.Count; i += 2)
            {
                var position = new Position(lines[i]);
                var rover = new Rover(grid, position);
                rover.MoveSteps(lines[i + 1]);
                rovers.Add(rover);
            }

            return rovers;
        }
    }
}
