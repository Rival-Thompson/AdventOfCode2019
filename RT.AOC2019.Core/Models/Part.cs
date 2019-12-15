using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace RT.AOC2019.Core.Models {
    public abstract class Part {
        protected Stopwatch _sw;
        protected int _number;
        protected int _day;
        private readonly string _inputFilePath;
        public Part (int number, int day, string inputFilePath) {
            _inputFilePath = inputFilePath;
            _sw = new Stopwatch ();
            _number = number;
            _day = day;
        }

        protected void Start () {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ($"Advent of Code 2019 - Day{_day}: Part{_number}");
            Console.ForegroundColor = ConsoleColor.White;
            _sw.Start ();
        }

        protected void Complete (string result) {
            _sw.Stop ();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ($"Result: {result}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Solution took {_sw.Elapsed} to get a result");
            _sw.Reset();
        }

        public async Task Run (){
            var input = await LoadData();
            Start();
            var result = Work(input);
            Complete(result);
        }

        protected abstract string Work(string data);

        public void Test () {
            Start ();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("----------------- Test Run ----------------");
            Console.ForegroundColor = ConsoleColor.White;

            var result = Work (LoadTestData ());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("----------------- Test Result ----------------");
            Console.ForegroundColor = ConsoleColor.White;
            Complete (result);

        }

        protected async Task<string> LoadData () {
            return await File.ReadAllTextAsync(_inputFilePath);
        }

        protected abstract string LoadTestData ();

    }
}
