using System;
using System.Linq;

using RT.AOC2019.Core.Models;

namespace RT.AOC2019.CMD.Day1
{
    public class Part1 : Part
    {
        public Part1() : base(1, 1, "./Day1/Data.txt")
        {
        }

        protected override string LoadTestData()
        {
            throw new NotImplementedException();
        }

        protected override string Work(string data)
        {
            var input = data.Split(Environment.NewLine).Select(x => double.Parse(x));
            var fueles = (input).Select(x => ((int)Math.Round(x / 3, MidpointRounding.ToZero)) - 2);
            var total = fueles.Sum();
            return total.ToString();
        }
    }
}
