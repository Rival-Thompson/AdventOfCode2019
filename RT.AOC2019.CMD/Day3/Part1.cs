using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RT.AOC2019.CMD.Extensions;

namespace RT.AOC2019.CMD.Day3
{
    public static class Part1V2
    {
        public static async Task Run()
        {
            Console.WriteLine("Day3: Part1");
            var lines = await LoadData();
            //lines = LoadTestData();
            var coordinateLists = lines.Select(x => LineToCoordinateList(x).Distinct().ToList());

            var allCoordinates = new List<Point>();
            foreach (var list in coordinateLists)
            {
                list.RemoveAt(0);
                allCoordinates.AddRange(list);
            }

            var interSections = FindInterSections(allCoordinates);

            var distances = interSections.Select(point => new { Distance = (Math.Abs(point.X) + Math.Abs(point.Y)), Coordinate = point });

            var closest = distances.OrderBy(x => x.Distance).First();

            Console.WriteLine($"Result: {closest.Coordinate} with a distance of {closest.Distance}");

        }

        public static string[] LoadTestData()
        {
            return new string[] { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };
            
        }

        private static List<Point> LineToCoordinateList(string line)
        {
            var sw = new Stopwatch();
            sw.Start();
            var instructions = line.Split(',').Select(x => new Instruction(x)).ToList();
            var points = new List<Point> { new Point(0,0)};
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
                            points.Add(new Point(p.X, p.Y +i));
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

        private static async Task<string[]> LoadData()
        {
            var input = await File.ReadAllTextAsync("./Day3/Data.txt");
            return input.Split(Environment.NewLine);
        }

        private static IEnumerable<Point> FindInterSections(IEnumerable<Point> coordinates)
        {
            var sw = new Stopwatch();
            sw.Start();
            var intersections = coordinates.Duplicates(x => x).ToList();
            sw.Stop();
            Console.WriteLine($"Finding intersections v2 took {sw.Elapsed}");
            return intersections.Distinct();
        }


    }
}
