﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RT.AOC2019.CMD.Day2
{
    public static class Part1
    {
        public static async Task Run()
        {
            Console.WriteLine("Day2: Part1");
            Test();
            var code = await LoadData();
            // initial manupliations
            code[1] = 12;
            code[2] = 2;

            InterpetateCode(ref code, 0);

            Console.WriteLine($"Result: ${code[0]}");
        }

        public static void Test()
        {
            Console.WriteLine("Testing Provided Example");
            var code = new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };

            InterpetateCode(ref code, 0);

            Console.WriteLine($"TEST: result = {string.Join(',', code)}");
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

        private static async Task<int[]> LoadData()
        {
            var input = await File.ReadAllTextAsync("./Day2/Part1.Data.txt");
            return input.Split(',').Select(x => int.Parse(x)).ToArray();
        }
    }
}