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
            var input = "amgozmfv";
            Console.WriteLine($"Part 1: {Day14.Part1(input)}");
            Console.WriteLine($"Part 2: {Day14.Part2(input)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
