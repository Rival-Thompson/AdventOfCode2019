using System;
using System.Linq;

using RT.AOC2019.Core.Models;

namespace RT.AOC2019.CMD.Day1
{
    public class Part2 : Part
    {
        public Part2() : base(2, 1, "./Day1/Data.txt")
        {
        }

        protected override string LoadTestData()
        {
            return "100756";
        }

        protected override string Work(string data)
        {
            var input = data.Split(Environment.NewLine).Select(x => double.Parse(x));
            var fueles = (input).Select(x => CalulateFuelForFuel(x));
            var total = fueles.Sum();
            return total.ToString();
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
    }
}
