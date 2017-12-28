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
            var path = "Input/Day22.txt";
            Console.WriteLine($"Part 1: {Day22.Part1(path, 10000)}");
            Console.WriteLine($"Part 2: {Day22.Part2(path, 10000000)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
