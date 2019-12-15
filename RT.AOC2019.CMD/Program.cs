using System;
using System.Threading.Tasks;

namespace RT.AOC2019.CMD
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Rival Thompsons Advend of Code 2019");
            await (new Day1.Part1()).Run();
            (new Day1.Part2()).Test();
            await (new Day1.Part2()).Run();
            await (new Day2.Part1()).Run();
            await (new Day2.Part2()).Run();
            (new Day3.Part1()).Test();
            await (new Day3.Part1()).Run();
            (new Day3.Part2()).Test();
            await (new Day3.Part2()).Run();

            Console.ReadLine();
        }
    }
}
