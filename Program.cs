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
            var path = "Input/Day16.txt";
            var dancers = "abcdefghijklmnop";
            Console.WriteLine($"Part 1: {Day16.Part1(path, dancers)}");
            Console.WriteLine($"Part 2: {Day16.Part2(path, dancers, 1000000000)}");
            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
