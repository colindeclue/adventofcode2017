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
            var path = "Input/Day23.txt";
            Console.WriteLine($"Part 1: {Day23.Part1(path)}");
            Console.WriteLine($"Part 2: {Day23.Part2()}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
