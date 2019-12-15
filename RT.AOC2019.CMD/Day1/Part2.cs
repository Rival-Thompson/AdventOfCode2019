using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RT.AOC2019.CMD.Day1
{
    public static class Part2
    {
        public static async Task Run()
        {
            Console.WriteLine("Day1: Part2");
            TextExample();
            var fueles = (await LoadData()).Select(x => CalulateFuelForFuel(x));
            var total = (int)fueles.Sum();
            Console.WriteLine($"Result: {total}");
        }

        public static void TextExample()
        {
            var mass = 100756;
            var fuel = (int)CalulateFuelForFuel(mass);
            Console.WriteLine($"TEST: fuel needed: {fuel}");
        }

        private static double CalulateFuelForFuel(double fuel)
        {
            var extraFuel = ((Math.Round(fuel / 3.0, MidpointRounding.ToZero)) - 2);
            if (extraFuel > 0)
            {
                return extraFuel + CalulateFuelForFuel(extraFuel);
            }
            return 0;
        }

        private static async Task<IEnumerable<double>> LoadData()
        {
            var input = await File.ReadAllTextAsync("./Day1/Part1.Data.txt");
            return input.Split(Environment.NewLine).Select(x => double.Parse(x));
        }
    }
}
