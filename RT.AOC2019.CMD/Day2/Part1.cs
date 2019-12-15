using System;
using System.Linq;

using RT.AOC2019.Core.Models;

namespace RT.AOC2019.CMD.Day2
{
    public class Part1 : Part
    {
        public Part1() : base(1, 2, "./Day2/Data.txt")
        {
        }

        protected override string LoadTestData()
        {
            return "1,9,10,3,2,3,11,0,99,30,40,50";
        }

        protected override string Work(string data)
        {
            var code = data.Split(',').Select(x => int.Parse(x)).ToArray();
            if (data != LoadTestData())
            {
                // initial manupliations
                code[1] = 12;
                code[2] = 2;
            }
            InterpetateCode(ref code, 0);
            return code[0].ToString();
        }

        private static void InterpetateCode(ref int[] array, int pos)
        {
            var exit = false;
            while (!exit)
            {
                switch (array[pos])
                {
                    case (1):
                        Add(ref array, pos);
                        break;

                    case (2):
                        Multiply(ref array, pos);
                        break;

                    case (99):
                        exit = true;
                        break;

                    default:
                        throw new NotSupportedException($"not a valid int code! {array[pos]}");
                }
                pos += 4;
            }
        }

        private static void Multiply(ref int[] array, int pos)
        {
            var input1 = array[pos + 1];
            var input2 = array[pos + 2];
            var outputPosition = array[pos + 3];
            array[outputPosition] = array[input1] * array[input2];
        }

        private static void Add(ref int[] array, int pos)
        {
            var input1 = array[pos + 1];
            var input2 = array[pos + 2];
            var outputPosition = array[pos + 3];
            array[outputPosition] = array[input1] + array[input2];
        }
    }
}
