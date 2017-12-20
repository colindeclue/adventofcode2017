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
            var path = "Input/Day20.txt";
            Console.WriteLine($"Part 1: {Day20.Part1(path)}");
            Console.WriteLine($"Part 2: {Day20.Part2(path)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
