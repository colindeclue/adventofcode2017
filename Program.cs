using System;
using System.Diagnostics;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var stepSize = 356;
            var steps = 2017;
            Console.WriteLine($"Part 1: {Day17.Part1(stepSize, steps)}");
            steps = 50000000;
            Console.WriteLine($"Part 2: {Day17.Part2(stepSize, steps)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
