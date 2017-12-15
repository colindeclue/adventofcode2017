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
            long genA = 634;
            long genB = 301;
            Console.WriteLine($"Part 1: {Day15.Part1(genA, genB, 40000000)}");
            Console.WriteLine($"Part 2: {Day15.Part2(genA, genB, 5000000)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
