using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using RT.AOC2019.CMD.Extensions;
using RT.AOC2019.Core.Models;

namespace RT.AOC2019.CMD.Day3
{
    public class Part2 : Part
    {
        public Part2() : base(2, 3, "./Day3/Data.txt")
        {
        }

        private static List<Point> LineToCoordinateList(string line)
        {
            var sw = new Stopwatch();
            sw.Start();
            var instructions = line.Split(',').Select(x => new Instruction(x)).ToList();
            var points = new List<Point> { new Point(0, 0) };
            foreach (var instruction in instructions)
            {
                var p = points.Last();
                for (int i = 1; i <= instruction.Moves; i++)
                {
                    switch (instruction.Direction)
                    {
                        case Direction.Right:
                            points.Add(new Point(p.X + i, p.Y));
                            break;

                        case Direction.Left:
                            points.Add(new Point(p.X - i, p.Y));
                            break;

                        case Direction.Up:
                            points.Add(new Point(p.X, p.Y + i));
                            break;

                        case Direction.Down:
                            points.Add(new Point(p.X, p.Y - i));
                            break;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Applying instructions took {sw.Elapsed}");
            return points;
        }

        private static IEnumerable<Intersection> FindInterSections(IEnumerable<Point> coordinates, IEnumerable<IEnumerable<Point>> lists)
        {
            var sw = new Stopwatch();
            sw.Start();
            var points = coordinates.Duplicates(x => x).Distinct().ToList();
            var intersections = points.Select(p => new Intersection(p, lists.Sum(l => l.IndexOf(p) + 1) + lists.Count()));
            sw.Stop();
            Console.WriteLine($"Finding intersections v2 took {sw.Elapsed}");
            return intersections;
        }

        protected override string Work(string data)
        {
            var lines = data.Split(Environment.NewLine);
            //lines = LoadTestData();
            var coordinateLists = lines.Select(x => LineToCoordinateList(x).Distinct().ToList()).ToList();

            var allCoordinates = new List<Point>();
            foreach (var list in coordinateLists)
            {
                list.RemoveAt(0);
                allCoordinates.AddRange(list);
            }

            var interSections = FindInterSections(allCoordinates, coordinateLists);

            var closest = interSections.OrderBy(x => x.TotalSteps).First();

            return $"{closest.Point} with a distance of {closest.TotalSteps}";
        }

        protected override string LoadTestData()
        {
            return $"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51{Environment.NewLine}U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
        }
    }
}
