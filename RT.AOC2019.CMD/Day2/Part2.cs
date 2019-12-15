using System;
using System.Linq;

using RT.AOC2019.Core.Models;

namespace RT.AOC2019.CMD.Day2
{
    public class Part2 : Part
    {
        public Part2() : base(2, 2, "./Day2/Data.txt")
        {
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

        protected override string Work(string data)
        {
            var input = data.Split(',').Select(x => int.Parse(x));
            var desiredResult = 19690720;
            var code = input.ToArray();
            var outcome = 0;
            var noun = 0;
            var verb = 0;

            for (noun = 0; noun <= code.Length; noun++)
            {
                for (verb = 0; verb < code.Length; verb++)
                {
                    code = input.ToArray();
                    // initial manupliations
                    code[1] = noun;
                    code[2] = verb;

                    InterpetateCode(ref code, 0);

                    outcome = code[0];
                    if (outcome == desiredResult)
                    {
                        break;
                    }
                }
                if (outcome == desiredResult)
                {
                    break;
                }
            }
            if (outcome == desiredResult)
                return (100 * noun + verb).ToString();
            else
                return "Not Found!";
        }

        protected override string LoadTestData()
        {
            throw new NotImplementedException();
        }
    }
}
