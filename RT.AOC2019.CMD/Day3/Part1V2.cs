using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RT.AOC2019.CMD.Extensions;

namespace RT.AOC2019.CMD.Day3
{
    public static class Part1
    {
        public static async Task Run()
        {
            Console.WriteLine("Day3: Part1");
            Test();
            var lines = await LoadData();
            var coordinateLists = lines.Select(x => LineToCoordinateList(x));

            var allCoordinates = new List<Coordinate>();
            foreach (var list in coordinateLists)
            {
                list.PrepForComparison();
                allCoordinates.AddRange(list.Coordinates);
            }

            var interSections = FindInterSections(allCoordinates);

            var distances = interSections.Select(point => new { Distance = point.DistanceBetween(Coordinate.NullPoint), Coordinate = point });

            var closest = distances.OrderBy(x => x.Distance).First();

            Console.WriteLine($"Result: {closest.Coordinate} with a distance of {closest.Distance}");

        }

        public static void Test()
        {
            var lines = new string[] { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };
            lines = new string[] { "R8,U5,L5,D3", "U7,R6,D4,L4" };
            var coordinateLists = lines.Select(x => LineToCoordinateList(x));

            var allCoordinates = new List<Coordinate>();
            foreach (var list in coordinateLists)
            {
                list.PrepForComparison();
                allCoordinates.AddRange(list.Coordinates);
            }

            var interSections = FindInterSections(allCoordinates);

            var distances = interSections.Select(point => new { Distance = point.DistanceBetween(Coordinate.NullPoint), Coordinate = point });

            var closest = distances.OrderBy(x => x.Distance).First();

            Console.WriteLine($"TestResult: {closest.Coordinate} with a distance of {closest.Distance}");
        }

        private static CoordinateList LineToCoordinateList(string line)
        {
            var sw = new Stopwatch();
            sw.Start();
            var list = new CoordinateList();
            var instructions = line.Split(',').Select(x => new Instruction(x)).ToList();
            foreach (var instruction in instructions)
            {
                instruction.Apply(list);
            }

            sw.Stop();
            Console.WriteLine($"Applying instructions took {sw.Elapsed}");
            return list;
        }

        private static async Task<string[]> LoadData()
        {
            var input = await File.ReadAllTextAsync("./Day3/Data.txt");
            return input.Split(Environment.NewLine);
        }

        private static IEnumerable<Coordinate> FindInterSections(IEnumerable<Coordinate> coordinates)
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
