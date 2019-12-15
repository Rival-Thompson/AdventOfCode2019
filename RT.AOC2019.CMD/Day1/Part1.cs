using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RT.AOC2019.CMD.Day1
{
    public static class Part1
    {
        public static async Task Run()
        {
            Console.WriteLine("Day1: Part1");
            var fueles =(await LoadData()).Select(x => ((int)Math.Round(x / 3,MidpointRounding.ToZero)) - 2);
            var total = fueles.Sum();
            Console.WriteLine($"Result: ${total}");
        }

        private static async Task<IEnumerable<double>> LoadData()
        {
            var input = await File.ReadAllTextAsync("./Day1/Part1.Data.txt");
            return input.Split(Environment.NewLine).Select(x => double.Parse(x));
        }
    }
}
