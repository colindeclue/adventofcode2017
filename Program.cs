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
            var path = "Input/Day21.txt";
            Console.WriteLine($"Part 1: {Day21.Part1(path, 5)}");
            Console.WriteLine($"Part 2: {Day21.Part1(path, 24)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
